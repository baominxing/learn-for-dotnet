using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleCode001
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Logout(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();

            Response.Redirect("Default.aspx");
        }
    }
}