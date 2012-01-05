using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Samples
{
    public partial class Herald : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Submit(object sender, EventArgs e)
        {
            Label1.Text = "You entered '" + Email1.Value + "', Now Enter your age";
            Number1.Enabled = true;
        }
    }
}