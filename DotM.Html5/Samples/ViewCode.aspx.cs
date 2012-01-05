using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Samples
{
    public partial class ViewCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var fileName = GetFileName();
            PrintFile(fileName);
        }

        private void PrintFile(string fileName)
        {
            LblHeader.Text = "Showing Code of file :" + fileName;
            try
            {
                var filePath = Server.MapPath(fileName);
                codeContainer.InnerHtml = Server.HtmlEncode(File.ReadAllText(filePath));
            }
            catch (Exception ex)
            {
                LblFooter.Text = ex.Message;
            }
        }

        private string GetFileName()
        {
            var p = Request.QueryString["p"];
            if (string.IsNullOrEmpty(p))
                p = "ViewCode.aspx";
            return "~/" + p;
        }
    }
}