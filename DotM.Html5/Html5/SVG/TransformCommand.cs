using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;

namespace DotM.Html5.SVG
{
    public class TransformCommand : ISerializable
    {
        public TransformCommand(TransformCommandType type, params double[] parameters)
        {
            Type = type;
            Parameters = parameters;
        }
        public double[] Parameters { get; private set; }
        public TransformCommandType Type { get; private set; }
        public TransformCommand Next { get; private set; }

        public TransformCommand Matrix(double a, double b, double c, double d, double e, double f)
        {
            return SetNext(new TransformCommand(TransformCommandType.Matrix, a, b, c, d, e, f));
        }
        public TransformCommand Translate(double x)
        {
            return SetNext(new TransformCommand(TransformCommandType.Translate, x));
        }
        public TransformCommand Translate(double x, double y)
        {
            return SetNext(new TransformCommand(TransformCommandType.Translate, x, y));
        }
        public TransformCommand Scale(double x)
        {
            return SetNext(new TransformCommand(TransformCommandType.Scale, x));
        }
        public TransformCommand Scale(double x, double y)
        {
            return SetNext(new TransformCommand(TransformCommandType.Scale, x,y));
        }
        public TransformCommand Rotate(double rotateAngle)
        {
            return SetNext(new TransformCommand(TransformCommandType.Rotate, rotateAngle));
        }
        public TransformCommand Rotate(double rotateAngle, double cx, double cy)
        {
            return SetNext(new TransformCommand(TransformCommandType.Rotate, rotateAngle, cx, cy));
        }
        public TransformCommand SkewX(double skewAngle)
        {
            return SetNext(new TransformCommand(TransformCommandType.SkewX, skewAngle));
        }
        public TransformCommand SkewY(double skewAngle)
        {
            return SetNext(new TransformCommand(TransformCommandType.SkewY, skewAngle));
        }

        public override string ToString()
        {
            var writer = new StringWriter();
            Write(writer);
            return writer.ToString();
        }

        private void Write(StringWriter writer)
        {
            writer.Write(GetMethodName());
            writer.Write('(');
            var seperator = "";
            foreach (var parameter in Parameters)
            {
                writer.Write(seperator);
                writer.Write(parameter);
                seperator = ",";
            }
            writer.Write(')');
            if (Next != null)
            {
                writer.Write(' ');
                Next.Write(writer);
            }
        }

        public static TransformCommand Parse(string input)
        {
            var regex = @"(.+?)\((.+?)\)";

            var matches = Regex.Matches(input, regex);
            TransformCommand first = null;
            TransformCommand last = null;

            foreach (Match match in matches)
            {
                var key = match.Groups[1].Value.Trim();
                var value = match.Groups[2].Value.Trim();
                TransformCommandType type;
                if (!Enum.TryParse<TransformCommandType>(key, true, out type))
                    throw new FormatException("Input string was not in correct format: " + input);
                var command = new TransformCommand(type, value.Split(new[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries).Select(n => double.Parse(n)).ToArray());
                if (first == null)
                    first = command;
                else
                    last.SetNext(command);
                last = command;
            }
            return first;
        }
        private string GetMethodName()
        {
            var typeString = Type.ToString();
            return char.ToLower(typeString[0]) + typeString.Substring(1);
        }

        public virtual TransformCommand SetNext(TransformCommand command) 
        {
            command.Next = Next;
            Next = command;
            return command;
        }
        public TransformCommand Last
        {
            get
            {
                var current = this;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                return current;
            }
        }
        public TransformCommand Append(TransformCommand command) 
        {
            return Last.SetNext(command);
        }
        public IEnumerable<TransformCommand> AsEnumerable()
        {
            var current = this;
            while (current != null)
            {
                yield return current;
                current = current.Next;
            }
        }

        #region Serialization

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Input", ToString());
        }

        private class TransformCommandSerializaionProxy : ISerializable, IObjectReference
        {
            string Input;
            public TransformCommandSerializaionProxy(SerializationInfo info, StreamingContext context)
            {
                Input = info.GetString("Input");
            }
            public object GetRealObject(StreamingContext context)
            {
                return TransformCommand.Parse(Input);
            }
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                throw new NotImplementedException();
            }
        }

        #endregion

    }
    public enum TransformCommandType
    { 
        Matrix,
        Translate,
        Scale,
        Rotate,
        SkewX,
        SkewY
    }
}
