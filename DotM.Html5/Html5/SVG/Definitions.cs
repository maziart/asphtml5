using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotM.Html5.SVG
{
    public class Definitions : SVGControl
    {
        public Definitions() : base(SVGControlType.Defs) { }
        protected override void AddAttributesToRender(System.Web.UI.HtmlTextWriter writer)
        {
            //Do nothing
        }
    }
}
