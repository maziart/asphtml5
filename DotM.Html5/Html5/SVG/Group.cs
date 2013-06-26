using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace DotM.Html5.SVG
{
    public class Group : SVGControl
    {
        public Group() : base(SVGControlType.G)
        {

        }
        public string Description { get { return GetViewState("Description", string.Empty); } set { SetViewState("Description", value); } }
        protected override void OnPreRender(EventArgs e)
        {
            AddDescElement();
            base.OnPreRender(e);
        }

        private void AddDescElement()
        {
            string desc = Description;
            if (!string.IsNullOrEmpty(desc))
            {
                Controls.AddAt(0, new LiteralControl(string.Format("<desc>{0}</desc>", desc)));
            }
        }
    }
}
