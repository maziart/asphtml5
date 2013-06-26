using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace DotM.Html5.SVG
{
    /// <summary>
    /// Defines an ellipse which is axis-aligned with the current user coordinate system based on
    /// a center point and two radii. 
    /// </summary>
    public class Ellipse : LineBase
    {
        public Ellipse()
            :base(SVGControlType.Ellipse)
        {
        }
        protected override void AddAttributesToRender(System.Web.UI.HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            Helper.AddUnitAttributeIfNotEmpty(writer, "cx", CX);
            Helper.AddUnitAttributeIfNotEmpty(writer, "cy", CY);
            Helper.AddUnitAttributeIfNotEmpty(writer, "rx", RadiusX);
            Helper.AddUnitAttributeIfNotEmpty(writer, "ry", RadiusY);
        }

        public string Fill { get { return Style["fill"]; } set { Style["fill"] = value; } }
        public Unit CX { get { return GetViewState("CX", Unit.Empty); } set { SetViewState("CX", value); } }
        public Unit CY { get { return GetViewState("CY", Unit.Empty); } set { SetViewState("CY", value); } }
        public Unit RadiusX { get { return GetViewState("RadiusX", Unit.Empty); } set { SetViewState("RadiusX", value); } }
        public Unit RadiusY { get { return GetViewState("RadiusY", Unit.Empty); } set { SetViewState("RadiusY", value); } }
        public Point Center { get { return new Point(CX, CY); } set { CX = value.X; CY = value.Y; } }
    }
}
