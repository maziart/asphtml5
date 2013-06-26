using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotM.Html5.SVG
{
    public class PolyLine : LineBase
    {
        internal PolyLine(SVGControlType type)
            :base(type)
        {
        }
        public PolyLine()
            : this(SVGControlType.PolyLine)
        {
            
        }
        protected override void AddAttributesToRender(System.Web.UI.HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            Helper.AddStringAttributeIfNotEmpty(writer, "points", Points);
        }
        private PointCollection _Points;
        public PointCollection Points { get { return _Points ?? (_Points = GetViewState("Points", new PointCollection())); } set { _Points = value; } }
        protected override void OnPreRender(EventArgs e)
        {
            SetViewState("Points", _Points);
            base.OnPreRender(e);
        }
        public string Fill { get { return Style["fill"]; } set { Style["fill"] = value; } }
    }
}
