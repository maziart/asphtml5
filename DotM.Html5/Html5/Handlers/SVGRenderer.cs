using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace DotM.Html5.Handlers
{
    public class SVGRenderer : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var page = new Page();
            var control = page.LoadControl("~/UC.ascx");
            
        }
    }
}
