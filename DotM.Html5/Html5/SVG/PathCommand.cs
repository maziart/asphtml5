using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;

namespace DotM.Html5.SVG
{
    public class PathCommandType
    {
        private PathCommandType(char character, int parameterCount, Type commandType)
        {
            Character = character;
            ParameterCount = parameterCount;
            CommandType = commandType;
            ImplicitNextType = this;
        }
        public char Character { get; private set; }
        public int ParameterCount { get; private set; }
        public char GetCharacter(bool absolute)
        {
            return absolute ? char.ToUpper(Character) : char.ToLower(Character);
        }
        public Type CommandType { get; private set; }
        public PathCommandType ImplicitNextType { get; private set; }
        static PathCommandType()
        {
            LineTo = new PathCommandType('L', 2, typeof(LineCommand));
            MoveTo = new PathCommandType('M', 2, typeof(MoveCommand));
            HorizontalLineTo = new PathCommandType('H', 1, typeof(HorizontalLineCommand));
            VerticalLineTo = new PathCommandType('V', 1, typeof(VerticalLineCommand));
            ClosePath = new PathCommandType('Z', 0, typeof(ClosePathCommand));
            CircleTo = new PathCommandType('C', 6, typeof(CircleCommand));
            SmoothCircleTo = new PathCommandType('S', 4, typeof(SmoothCircleCommand));
            QuadricCurve = new PathCommandType('Q', 4, typeof(QuadricCurveCommand));
            SmoothQuadricCurve = new PathCommandType('T', 2, typeof(SmoothQuadricCurveCommand));
            Arc = new PathCommandType('A', 7, typeof(ArcCommand));

            MoveTo.ImplicitNextType = LineTo;
        }
        public static PathCommandType[] GetAll()
        {
            return new[] 
            {
                MoveTo,
                LineTo,
                HorizontalLineTo,
                VerticalLineTo,
                ClosePath,
                CircleTo,
                SmoothCircleTo,
                QuadricCurve,
                SmoothQuadricCurve,
                Arc
            };
        }
        public static readonly PathCommandType MoveTo;
        public static readonly PathCommandType LineTo;
        public static readonly PathCommandType HorizontalLineTo;
        public static readonly PathCommandType VerticalLineTo;
        public static readonly PathCommandType ClosePath;
        public static readonly PathCommandType CircleTo;
        public static readonly PathCommandType SmoothCircleTo;
        public static readonly PathCommandType QuadricCurve;
        public static readonly PathCommandType SmoothQuadricCurve;
        public static readonly PathCommandType Arc;
    }
    [Serializable]
    public abstract class PathCommand : ISerializable
    {
        public PathCommand(PathCommandType type, bool absolute)
        {
            Type = type;
            Absolute = absolute;
        }
        public bool Absolute { get; protected set; }
        public PathCommandType Type { get; private set; }


        public PathCommand LastCommand
        {
            get
            {
                PathCommand current = this;
                PathCommand next;
                while ((next = current.Next) != null)
                {
                    current = next;
                }
                return current;
            }
        }
        public string GetPathData()
        {
            var writer = new StringWriter();
            Write(writer, true);
            return writer.ToString();
        }
        public override string ToString()
        {
            return GetPathData();
        }

        protected virtual void Write(StringWriter writer, bool writeNext)
        {
            writer.Write(Type.GetCharacter(Absolute));
            var current = this;
            var next = current.Next;
            do
            {
                current.WriteData(writer);
                if (!writeNext || next == null || (next.Absolute != Absolute) || Type.ImplicitNextType != next.Type)
                    break;
                writer.Write(' ');
                current = next;
                next = current.Next;
            } while (true);
            if (writeNext && next != null)
                next.Write(writer, true);
        }
        protected abstract void WriteData(StringWriter writer);

        public virtual T SetNext<T>(T command) where T : PathCommand
        {
            command.Next = Next;
            return AppendNext<T>(command);
        }

        private T AppendNext<T>(T command) where T : PathCommand
        {
            Next = command;
            return command;
        }
        protected PathCommand Next { get; private set; }

        public IEnumerable<PathCommand> AsEnumerable()
        {
            var current = this;
            while (current != null)
            {
                yield return current;
                current = current.Next;
            }
        }

        #region Serializing
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.SetType(typeof(PathCommandSerializationProxy));
            info.AddValue("d", GetPathData());
        }
        [Serializable]
        private class PathCommandSerializationProxy : ISerializable, IObjectReference
        {
            private string Input;
            public PathCommandSerializationProxy(SerializationInfo info, StreamingContext context)
            {
                Input = info.GetString("d");
            }
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                throw new NotSupportedException("Don't serialize me!");
            }

            public object GetRealObject(StreamingContext context)
            {
                return PathCommand.Parse(Input);
            }
        } 
        #endregion

        #region Fluent Command Adding
        /// <summary>
        /// Start a new sub-path at the given (x,y) coordinate.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="absolute"></param>
        /// <returns></returns>
        public MoveCommand MoveTo(double x, double y, bool absolute = true)
        {
            return SetNext(new MoveCommand(x, y, absolute));
        }
        /// <summary>
        /// Close the current subpath by drawing a straight line from the current point to current subpath's
        /// initial point
        /// </summary>
        /// <returns></returns>
        public ClosePathCommand ClosePath()
        {
            return SetNext(new ClosePathCommand());
        }
        /// <summary>
        /// Draw a line from the current point to the given (x,y) coordinate which becomes the new current point
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="absolute"></param>
        /// <returns></returns>
        public LineCommand LineTo(double x, double y, bool absolute = false)
        {
            return SetNext(new LineCommand(x, y, absolute));
        }
        /// <summary>
        /// Draws a horizontal line from the current point (cpx, cpy) to (x, cpy)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="absolute"></param>
        /// <returns></returns>
        public HorizontalLineCommand HorizontalLineTo(double x, bool absolute = false)
        {
            return SetNext(new HorizontalLineCommand(x, absolute));
        }
        /// <summary>
        /// Draws a vertical line from the current point (cpx, cpy) to (cpx, y)
        /// </summary>
        /// <param name="y"></param>
        /// <param name="absolute"></param>
        /// <returns></returns>
        public VerticalLineCommand VerticalLineTo(double y, bool absolute = false)
        {
            return SetNext(new VerticalLineCommand(y, absolute));
        }
        /// <summary>
        /// Draws a cubic Bezier curve from the current point to (x,y) using (x1,y1) as the control point 
        /// at the beginning of the curve and (x2,y2) as the control point at the end of the curve
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="absolute"></param>
        /// <returns></returns>
        public CircleCommand CircleTo(double x1, double y1, double x2, double y2, double x, double y, bool absolute = false)
        {
            return SetNext(new CircleCommand(x1, y1, x2, y2, x, y, absolute));
        }
        /// <summary>
        /// Draws a cubic Bezier curve from the current point to (x,y). The first control point is assumed
        /// to be the reflection of the second control point on the previous command relative to the current point.
        /// (If there is no previous command or if the previous command was not an CircleCommand or a SmoothCircleCommand, 
        /// assume the first control point is coincident with the current point.) 
        /// </summary>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="absolute"></param>
        /// <returns></returns>
        public SmoothCircleCommand SmoothCircleTo(double x2, double y2, double x, double y, bool absolute = false)
        {
            return SetNext(new SmoothCircleCommand(x2, y2, x, y, absolute));
        }
        /// <summary>
        /// Draws a quadratic Bezier curve from the current point to (x,y) using (x1,y1) as the control point
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="absolute"></param>
        /// <returns></returns>
        public QuadricCurveCommand QuadricCurveTo(double x1, double y1, double x, double y, bool absolute = false)
        {
            return SetNext(new QuadricCurveCommand(x1, y1, x, y, absolute));
        }
        /// <summary>
        /// Draws a quadratic Bezier curve from the current point to (x,y). The control point is assumed to
        /// be the reflection of the control point on the previous command relative to the current point. 
        /// (If there is no previous command or if the previous command was not a QuadricCurveCommand 
        /// or a SmoothQuadricCurveCommand, assume the control point is coincident with the current point.)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="absolute"></param>
        /// <returns></returns>
        public SmoothQuadricCurveCommand SmoothQuadricCurveTo(double x, double y, bool absolute = false)
        {
            return SetNext(new SmoothQuadricCurveCommand(x, y, absolute));
        }
        /// <summary>
        /// Draws an elliptical arc from the current point to (x, y). The size and orientation of the ellipse 
        /// are defined by two radii (rx, ry) and an x-axis-rotation, which indicates how the ellipse as a whole 
        /// is rotated relative to the current coordinate system. The center (cx, cy) of the ellipse is calculated 
        /// automatically to satisfy the constraints imposed by the other parameters. large-arc-flag and sweep-flag 
        /// contribute to the automatic calculations and help determine how the arc is drawn.
        /// </summary>
        /// <param name="rx"></param>
        /// <param name="ry"></param>
        /// <param name="xAxisRotation"></param>
        /// <param name="largeArc"></param>
        /// <param name="sweep"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="absolute"></param>
        /// <returns></returns>
        public ArcCommand ArcTo(double rx, double ry, double xAxisRotation, bool largeArc, bool sweep, double x, double y, bool absolute = false)
        {
            return SetNext(new ArcCommand(rx, ry, xAxisRotation, largeArc, sweep, x, y, absolute));
        }
        #endregion

        #region Parsing
        public static PathCommand Parse(string str)
        {
            var parser = new PathCommandParser(str);
            parser.Parse();
            return parser.FirstCommand;

        }
        private class PathCommandParser
        {
            private string Input;
            private int LookAhead;
            private PathCommandType[] CommandTypes;
            public PathCommandParser(string input)
            {
                Input = input;
                CommandTypes = PathCommandType.GetAll();
            }
            Token PrevToken;
            public PathCommand FirstCommand { get; private set; }
            PathCommand LastCommand;
            public void Parse()
            {
                var token = GetNextToken();
                if (token == null)
                    return;
                if (token.Type != TokenType.Command || token.CommandType == null)
                    ThrowFormatException();
            START:
                var commandType = token.CommandType;
                var absolute = token.CommandIsAbsolute;
                var values = new List<double>();
                while ((token = GetNextToken()) != null && token.Type != TokenType.Command)
                {
                    if (token.Type == TokenType.Seperator)
                        continue;
                    values.Add(token.Value);
                }
                var command = CreateCommand(commandType, values, absolute);
                if (LastCommand == null)
                {
                    FirstCommand = command;
                }
                else
                {
                    LastCommand.AppendNext(command);
                }
                LastCommand = command.LastCommand;
                if (token == null)
                    return;
                goto START;
            }

            private PathCommand CreateCommand(PathCommandType type, List<double> values, bool absolute)
            {
                if (values.Count < type.ParameterCount)
                    ThrowFormatException();

                var commandType = type.CommandType;
                var constructor = commandType.GetConstructors().FirstOrDefault();
                var parameterTypes = constructor.GetParameters();
                var parameters = new object[parameterTypes.Length];
                for (int i = 0; i < parameters.Length; i++)
                {
                    object value;
                    if (parameterTypes[i].Name == "absolute")
                        value = absolute;
                    else if (parameterTypes[i].ParameterType.Name == "Boolean")
                        value = values[i] == 1;
                    else
                        value = values[i];
                    parameters[i] = value;
                }
                var command = (PathCommand)constructor.Invoke(parameters);
                if (values.Count > type.ParameterCount)
                {
                    if (type.ImplicitNextType == null)
                        ThrowFormatException();
                    var next = CreateCommand(type.ImplicitNextType, values.Skip(type.ParameterCount).ToList(), absolute);
                    command.AppendNext(next);
                }
                return command;
            }
            private Token GetNextToken()
            {
                if (LookAhead >= Input.Length)
                    return null;
                var chars = new List<char>();
                var tokenType = GetTokenType(Input[LookAhead]);
                do
                {
                    chars.Add(Input[LookAhead]);
                    LookAhead++;
                }
                while (LookAhead < Input.Length && tokenType != TokenType.Command && GetTokenType(Input[LookAhead]) == tokenType);
                return CreateToken(chars, tokenType);
            }

            private Token CreateToken(List<char> chars, TokenType tokenType)
            {
                if (tokenType == TokenType.Command)
                {
                    PathCommandType commandType = null;
                    if (chars.Count != 1 || (commandType = CommandTypes.SingleOrDefault(n => char.ToLower(n.Character) == char.ToLower(chars[0]))) == null)
                        ThrowFormatException();
                    return new Token(TokenType.Command, 0, commandType, char.IsUpper(chars[0]));
                }
                if (tokenType == TokenType.Seperator)
                {
                    return new Token(TokenType.Seperator, 0, null, false);
                }
                if (tokenType == TokenType.Value)
                {
                    double value;
                    if (!double.TryParse(new string(chars.ToArray()), out value))
                        ThrowFormatException();
                    return new Token(TokenType.Value, value, null, false);
                }
                ThrowFormatException();
                return null;
            }
            private void ThrowFormatException()
            {
                throw new FormatException("Input wan not in correct format: " + Input);
            }
            private TokenType GetTokenType(char c)
            {
                if (char.IsWhiteSpace(c) || c == ',')
                    return TokenType.Seperator;
                if (char.IsDigit(c) || c == '.' || c == '-')
                    return TokenType.Value;
                if (CommandTypes.Any(n => char.ToLower(n.Character) == char.ToLower(c)))
                    return TokenType.Command;
                return TokenType.None;
            }
            private class Token
            {
                public double Value { get; private set; }
                public PathCommandType CommandType { get; private set; }
                public TokenType Type { get; private set; }
                public bool CommandIsAbsolute;
                public Token(TokenType type, double value, PathCommandType commandType, bool commandIsAbsolute)
                {
                    Type = type;
                    Value = value;
                    CommandType = commandType;
                    CommandIsAbsolute = commandIsAbsolute;
                }
            }
            private enum TokenType
            {
                None,
                Value,
                Seperator,
                Command
            }
        }
        #endregion

    }


    #region Commands
    [Serializable]
    public class ClosePathCommand : PathCommand
    {
        public ClosePathCommand()
            : base(PathCommandType.ClosePath, true)
        {
        }

        protected override void WriteData(StringWriter writer)
        {
        }
    }
    [Serializable]
    public class MoveCommand : PathCommand
    {
        private double X;
        private double Y;
        public MoveCommand(double x, double y, bool absolute)
            : base(PathCommandType.MoveTo, absolute)
        {
            X = x;
            Y = y;

        }

        public MoveCommand Set(double x, double y, bool absolute = true)
        {
            X = x;
            Y = y;
            Absolute = absolute;
            return this;
        }
        protected override void WriteData(StringWriter writer)
        {
            writer.Write(X);
            writer.Write(' ');
            writer.Write(Y);
        }
        public static MoveCommand Parse(string str)
        {
            return (MoveCommand)PathCommand.Parse(str);
        }
    }
    [Serializable]
    public class LineCommand : PathCommand
    {
        private double X;
        private double Y;

        public LineCommand(double x, double y, bool absolute)
            : base(PathCommandType.LineTo, absolute)
        {
            X = x;
            Y = y;

        }
        protected override void WriteData(StringWriter writer)
        {
            writer.Write(X);
            writer.Write(' ');
            writer.Write(Y);
        }
    }
    [Serializable]
    public class HorizontalLineCommand : PathCommand
    {
        private double X;

        public HorizontalLineCommand(double x, bool absolute)
            : base(PathCommandType.HorizontalLineTo, absolute)
        {
            X = x;
        }
        protected override void WriteData(StringWriter writer)
        {
            writer.Write(X);
        }
    }
    [Serializable]
    public class VerticalLineCommand : PathCommand
    {
        private double Y;

        public VerticalLineCommand(double y, bool absolute)
            : base(PathCommandType.VerticalLineTo, absolute)
        {
            Y = y;
        }
        protected override void WriteData(StringWriter writer)
        {
            writer.Write(Y);
        }
    }
    [Serializable]
    public class CircleCommand : PathCommand
    {
        private double X1;
        private double Y1;
        private double X2;
        private double Y2;
        private double X;
        private double Y;
        public CircleCommand(double x1, double y1, double x2, double y2, double x, double y, bool absolute)
            : base(PathCommandType.CircleTo, absolute)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            X = x;
            Y = y;
        }
        protected override void WriteData(StringWriter writer)
        {
            writer.Write(X1);
            writer.Write(' ');
            writer.Write(Y1);
            writer.Write(' ');
            writer.Write(X2);
            writer.Write(' ');
            writer.Write(Y2);
            writer.Write(' ');
            writer.Write(X);
            writer.Write(' ');
            writer.Write(Y);
        }
    }
    [Serializable]
    public class SmoothCircleCommand : PathCommand
    {
        private double X2;
        private double Y2;
        private double X;
        private double Y;
        public SmoothCircleCommand(double x2, double y2, double x, double y, bool absolute)
            : base(PathCommandType.SmoothCircleTo, absolute)
        {
            X2 = x2;
            Y2 = y2;
            X = x;
            Y = y;
        }
        protected override void WriteData(StringWriter writer)
        {
            writer.Write(X2);
            writer.Write(' ');
            writer.Write(Y2);
            writer.Write(' ');
            writer.Write(X);
            writer.Write(' ');
            writer.Write(Y);
        }
    }
    [Serializable]
    public class QuadricCurveCommand : PathCommand
    {
        private double X1;
        private double Y1;
        private double X;
        private double Y;
        public QuadricCurveCommand(double x1, double y1, double x, double y, bool absolute)
            : base(PathCommandType.QuadricCurve, absolute)
        {
            X1 = x1;
            Y1 = y1;
            X = x;
            Y = y;
        }
        protected override void WriteData(StringWriter writer)
        {
            writer.Write(X1);
            writer.Write(' ');
            writer.Write(Y1);
            writer.Write(' ');
            writer.Write(X);
            writer.Write(' ');
            writer.Write(Y);
        }
    }
    [Serializable]
    public class SmoothQuadricCurveCommand : PathCommand
    {
        private double X;
        private double Y;
        public SmoothQuadricCurveCommand(double x, double y, bool absolute)
            : base(PathCommandType.SmoothQuadricCurve, absolute)
        {
            X = x;
            Y = y;
        }
        protected override void WriteData(StringWriter writer)
        {
            writer.Write(X);
            writer.Write(' ');
            writer.Write(Y);
        }
    }
    [Serializable]
    public class ArcCommand : PathCommand
    {
        private double RX;
        private double RY;
        private double XAxisRotation;
        private bool LargeArc;
        private bool Sweep;
        private double X;
        private double Y;
        public ArcCommand(double rx, double ry, double xAxisRotation, bool largeArc, bool sweep, double x, double y, bool absolute)
            : base(PathCommandType.Arc, absolute)
        {
            RX = rx;
            RY = ry;
            XAxisRotation = xAxisRotation;
            LargeArc = largeArc;
            Sweep = sweep;
            X = x;
            Y = y;
        }

        protected override void WriteData(StringWriter writer)
        {
            writer.Write(RX);
            writer.Write(' ');
            writer.Write(RY);
            writer.Write(' ');
            writer.Write(XAxisRotation);
            writer.Write(' ');
            writer.Write(LargeArc ? 1 : 0);
            writer.Write(' ');
            writer.Write(Sweep ? 1 : 0);
            writer.Write(' ');
            writer.Write(X);
            writer.Write(' ');
            writer.Write(Y);
        }
    }
    #endregion
}


