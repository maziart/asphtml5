using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace DotM.Html5.SVG
{
    public class Line : LineBase
    {
        public Line()
            : base(SVGControlType.Line)
        {

        }

        protected override void AddAttributesToRender(System.Web.UI.HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            Helper.AddUnitAttributeIfNotEmpty(writer, "x1", X1);
            Helper.AddUnitAttributeIfNotEmpty(writer, "y1", Y1);
            Helper.AddUnitAttributeIfNotEmpty(writer, "x2", X2);
            Helper.AddUnitAttributeIfNotEmpty(writer, "y2", Y2);
        }

        public Unit X1 { get { return GetViewState("X1", Unit.Empty); } set { SetViewState("X1", value); } }
        public Unit X2 { get { return GetViewState("X2", Unit.Empty); } set { SetViewState("X2", value); } }
        public Unit Y1 { get { return GetViewState("Y1", Unit.Empty); } set { SetViewState("Y1", value); } }
        public Unit Y2 { get { return GetViewState("Y2", Unit.Empty); } set { SetViewState("Y2", value); } }

        public Point Start { get { return new Point(X1, Y1); } set { X1 = value.X; Y1 = value.Y; } }
        public Point End { get { return new Point(X2, Y2); } set { X2 = value.X; Y2 = value.Y; } }

        
    }
}
