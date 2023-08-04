using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.Win32;
using SampleCode001.Filters;
using SampleCode001.Models;
using WebMatrix.WebData;

namespace SampleCode001.Controllers
{
    [InitializeSimpleMembership]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            WebSecurity.Logout();

            return Redirect("~/Account/Login");
        }


        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel input)
        {
            bool success = WebSecurity.Login(input.Username, input.Password, input.Remember == "on");
            if (success)
            {
                var returnUrl = HttpContext.Request.QueryString["ReturnUrl"];

                if (string.IsNullOrEmpty(returnUrl))
                {
                    return Json(new { redirectUrl = "/" });
                }

                return Json(new { redirectUrl = returnUrl });
            }
            return View("Error");
        }

        [HttpPost]
        public ActionResult Register(RegisterModel input)
        {
            if (ModelState.IsValid)
            {
                WebSecurity.CreateUserAndAccount(input.Username, input.Password, new { Sex = input.Sex, Age = input.Age }, false);

                // 创建用户的时候根据名称归属角色
                if (input.Username == "Admin")
                {
                    using (var context = new ApplicationContext())
                    {
                        var user_admin = context.Set<UserProfile>().FirstOrDefault(s => s.UserName == input.Username);

                        var role_admin = context.Set<Role>().FirstOrDefault(s => s.RoleName == "Admin");

                        var user_role = new UsersInRole() { UserId = user_admin.UserId, RoleId = role_admin.RoleId };

                        context.Set<UsersInRole>().Add(user_role);

                        context.SaveChanges();
                    }
                }
                else
                {
                    using (var context = new ApplicationContext())
                    {
                        var user_admin = context.Set<UserProfile>().FirstOrDefault(s => s.UserName == input.Username);

                        var role_admin = context.Set<Role>().FirstOrDefault(s => s.RoleName == "User");

                        var user_role = new UsersInRole() { UserId = user_admin.UserId, RoleId = role_admin.RoleId };

                        context.Set<UsersInRole>().Add(user_role);

                        context.SaveChanges();
                    }
                }

                return Redirect("~/Account/Login");
            }

            return View("Error");
        }

        /// <summary>
        /// 创建角色方法，直接手动执行脚本创建两个角色
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateRole()
        {
            // //INSERT INTO [dbo].[webpages_Roles] ([RoleName]) VALUES ('Admin'),('User') 
            return View();
        }
    }

    public class LoginModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Remember { get; set; }
    }
    public class RegisterModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Sex { get; set; }

        public int Age { get { return new Random().Next(1, 100); } set { value = new Random().Next(1, 100); } }
    }
}