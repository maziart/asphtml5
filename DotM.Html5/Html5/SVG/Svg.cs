using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotM.Html5.SVG
{
    public class Svg : SVGControl
    {
        public Svg()
            :base(SVGControlType.SVG)
        {

        }
        public Svg(SVGUserControl userControl)
            :base(SVGControlType.SVG)
        {
            foreach (Control control in userControl.Controls)
            {
                Controls.Add(control);
            }
            userControl.Controls.Clear();
            foreach (string key in userControl.Attributes.Keys)
            {
                SetAttribute(key, userControl.Attributes[key]);
            }
            userControl.Attributes.Clear();
            Width = userControl.Width;
            Height = userControl.Height;
            ViewBox = userControl.ViewBox;
        }

        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            writer.AddAttribute("version", "1.1");
            Helper.AddUnitAttributeIfNotEmpty(writer, "width", Width);
            Helper.AddUnitAttributeIfNotEmpty(writer, "height", Height);
            Helper.AddStringAttributeIfNotEmpty(writer, "viewbox", ViewBox);
            base.AddAttributesToRender(writer);
        }


        public Unit Width { get { return GetViewState("Width", Unit.Empty); } set { SetViewState("Width", value); } }
        public Unit Height { get { return GetViewState("Height", Unit.Empty); } set { SetViewState("Height", value); } }
        public string ViewBox { get { return GetViewState("ViewBox", string.Empty); } set { SetViewState("ViewBox", value); } }
    }
}
