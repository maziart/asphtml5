using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace DotM.Html5.SVG
{
    /// <summary>
    /// The ‘circle’ element defines a circle based on a center point and a radius.
    /// </summary>
    public class Circle : LineBase
    {
        public Circle()
            : base(SVGControlType.Circle)
        {
        }
        protected override void AddAttributesToRender(System.Web.UI.HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            Helper.AddUnitAttributeIfNotEmpty(writer, "cx", CX);
            Helper.AddUnitAttributeIfNotEmpty(writer, "cy", CY);
            Helper.AddUnitAttributeIfNotEmpty(writer, "r", Radius);
        }

        public string Fill { get { return Style["fill"]; } set { Style["fill"] = value; } }
        public Unit CX { get { return GetViewState("CX", Unit.Empty); } set { SetViewState("CX", value); } }
        public Unit CY { get { return GetViewState("CY", Unit.Empty); } set { SetViewState("CY", value); } }
        public Unit Radius { get { return GetViewState("Radius", Unit.Empty); } set { SetViewState("Radius", value); } }
        public Point Center { get { return new Point(CX, CY); } set { CX = value.X; CY = value.Y; } }
    }
}
