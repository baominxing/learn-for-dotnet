using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleCode002
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Login(object sender, EventArgs e)
        {
            var username = Request["Username"];
            var password = Request["Password"];
            var userrole = "";
            var remember = Convert.ToBoolean(Request["Remember"] == "on");

            if (FormsAuthentication.Authenticate(username, password))
            {
                // 这种方式无法对用户进行分配角色内容
                // FormsAuthentication.RedirectFromLoginPage(username, remember);

                switch (username)
                {
                    case "admin":
                        userrole = "admin";
                        break;
                    case "user":
                        userrole = "user";
                        break;
                    default:
                        break;
                }

                // 创建一个身份验证票据
                var ticket = new FormsAuthenticationTicket(1, username, DateTime.Now, DateTime.Now.AddMinutes(30), remember, userrole);

                // 加密票据
                var encrypt_ticket = FormsAuthentication.Encrypt(ticket);

                // 创建cookie
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypt_ticket);

                Response.Cookies.Add(cookie);

                Response.Redirect("Default.aspx");
            }
            else
            {
                FormsAuthentication.RedirectToLoginPage();
            }
        }
    }
}