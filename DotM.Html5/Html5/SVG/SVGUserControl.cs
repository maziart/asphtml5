using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.ComponentModel;
using System.Web.UI.WebControls;

namespace DotM.Html5.SVG
{
    public abstract class SVGUserControl : UserControl
    {
        public SVGUserControl()
        {
            
        }

        //protected override void Render(HtmlTextWriter writer)
        //{
        //    //CheckControlTypes(Controls);
        //    var container = new Svg(this);
        //    Controls.Add(container);
        //    container.RenderControl(writer);
        //}

        private void CheckControlTypes(ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (!(control is SVGControl))
                    throw new InvalidOperationException("Control of type '" + control.GetType().FullName + "' Cannot be nested inside SVG User Control. Only Elements inherited from 'DotM.Html5.SVG.SVGControl' can be used");
                CheckControlTypes(control.Controls);
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override bool EnableTheming { get { return false; } set { } }


        public Unit Height { get; set; }
        public Unit Width { get; set; }

        public string ViewBox { get; set; }
    }
}
