using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace DotM.Html5.SVG
{
    /// <summary>
    /// Defines a rectangle which is axis-aligned with the current user coordinate system.
    /// </summary>
    public class Rectangle : LineBase
    {
        public Rectangle() :base(SVGControlType.Rect)
        {

        }
        protected override void AddAttributesToRender(System.Web.UI.HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);

            Helper.AddUnitAttributeIfNotEmpty(writer, "x", X);
            Helper.AddUnitAttributeIfNotEmpty(writer, "y", Y);
            Helper.AddUnitAttributeIfNotEmpty(writer, "width", Width);
            Helper.AddUnitAttributeIfNotEmpty(writer, "height", Height);
            Helper.AddUnitAttributeIfNotEmpty(writer, "rx", RX);
            Helper.AddUnitAttributeIfNotEmpty(writer, "ry", RX);
        }
        public string Fill { get { return Style["fill"]; } set { Style["fill"] = value; } }
        public Unit X { get { return GetViewState("X", Unit.Empty); } set { SetViewState("X", value); } }
        public Unit Y { get { return GetViewState("Y", Unit.Empty); } set { SetViewState("Y", value); } }
        public Unit Width { get { return GetViewState("Width", Unit.Empty); } set { SetViewState("Width", value); } }
        public Unit Height { get { return GetViewState("Height", Unit.Empty); } set { SetViewState("Height", value); } }
        public Unit RX { get { return GetViewState("RX", Unit.Empty); } set { SetViewState("RX", value); } }
        public Unit RY { get { return GetViewState("RY", Unit.Empty); } set { SetViewState("RY", value); } }
        public Point Start { get { return new Point(X, Y); } set { X = value.X; Y = value.Y; } }
        public Point Size { get { return new Point(Width, Height); } set { Width = value.X; Height = value.Y; } }
    }
}
