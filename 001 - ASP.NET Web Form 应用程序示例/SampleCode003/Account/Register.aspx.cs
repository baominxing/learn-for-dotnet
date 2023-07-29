using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleCode003
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateUserWizard1_CreateUser(object sender, EventArgs e)
        {
            Roles.AddUserToRoles(this.CreateUserWizard1.UserName, new string[] { "admin", "user" });
        }
    }
}