using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Profile;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using SampleCode003.Business;

namespace SampleCode003
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateUserWizard1_CreateUser(object sender, EventArgs e)
        {
            var profile = HttpContext.Current.Profile;

            profile["FirstName"] = "Fred";
            profile["LastName"] = "Bao";

            profile.Save();

            Roles.AddUserToRoles(this.CreateUserWizard1.UserName, new string[] { "admin", "user" });
        }
    }
}