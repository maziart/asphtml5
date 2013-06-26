using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotM.Html5.SVG
{
    public abstract class LineBase : SVGControl
    {
        public LineBase(SVGControlType type) : base(type) { }
        public string Stroke { get { return Style["Stroke"]; } set { Style["Stroke"] = value; } }
        public string StrokeWidth { get { return Style["Stroke-Width"]; } set { Style["Stroke-Width"] = value; } }
        public string StrokeOpacity { get { return Style["Stroke-Opacity"]; } set { Style["Stroke-Opacity"] = value; } }
        public string StrokeDashArray { get { return Style["Stroke-DashArray"]; } set { Style["Stroke-DashArray"] = value; } }
        public StrokeLineCapMode StrokeLineCap
        {
            get { return (StrokeLineCapMode)Enum.Parse(typeof(StrokeLineCapMode), Style["Stroke-LineCap"], true); }
            set { Style["Stroke-LineCap "] = value.ToString().ToLower(); }
        }
        
    }
}
