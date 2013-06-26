using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace DotM.Html5.SVG
{
    /// <summary>
    /// Represents a point in Cartesian coordinate system
    /// </summary>
    [Serializable]
    public struct Point
    {
        private Unit _X;
        private Unit _Y;
        /// <summary>
        /// X value in Cartesian system
        /// </summary>
        public Unit X { get { return _X; } }
        /// <summary>
        /// Y value in Cartesian system
        /// </summary>
        public Unit Y { get { return _Y; } }

        /// <summary>
        /// Creates a new instance of PoUnit
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        public Point(Unit x, Unit y)
            : this()
        {
            _X = x;
            _Y = y;
        }
        public override string ToString()
        {
            return ToString(',');
        }
        public string ToString(char seperator)
        {
            var sep = char.IsWhiteSpace(seperator) ? seperator.ToString() : seperator + " ";
            return string.Format("{0}{1}{2}", Helper.UnitToString(_X), sep, Helper.UnitToString(_Y));
        }
        public static Point Parse(string input)
        {
            var values = input.Split(',');
            if (values.Length != 2)
                values = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            Unit x, y;
            if (values.Length != 2 || !Helper.TryParseUnit(values[0].Trim(), out x) || !Helper.TryParseUnit(values[1].Trim(), out y))
                throw new FormatException("Input string is not in correct format of a Point: " + input);
            return new Point(x, y);
        }

        public static implicit operator string(Point point)
        {
            if (point == null)
                return null;
            return point.ToString();
        }
        public static implicit operator Point(string input)
        {
            if (input == null)
                return null;
            return Point.Parse(input);
        }
    }
}