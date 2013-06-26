using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotM.Html5.SVG
{
    /// <summary>
    /// Defines a closed shape consisting of a set of connected straight line segments
    /// </summary>
    public class Polygon : PolyLine
    {
        public Polygon()
            : base(SVGControlType.Polygon)
        {

        }
        public string Fill { get { return Style["fill"]; } set { Style["fill"] = value; } }
    }
}
