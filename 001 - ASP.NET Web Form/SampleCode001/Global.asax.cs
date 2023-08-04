using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace SampleCode001
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            // 认证事件处理顺序
            // formsauthenticationmodule.authenticateRequest事件处理程序，在这个事件处理程序里，User对象被初始化，赋予相关属性，比如IsAuthenticated
            ////////////////////////////////////////////////////////////
            // Step 6: Create a user object for the ticket
            // e.Context.SetPrincipalNoDemand(new GenericPrincipal(new FormsIdentity(ticket2), new String[0]));
            // custommodule.authenticateRequest事件处理程序
            // global.authenticateRequest事件处理程序
            // global.application_authenticateRequest方法

            var request = (HttpApplication)sender;

            // 判断用户身份验证信息是否为空 
            if (request.User == null) return;

            // 判断是否通过身份验证
            if (request.User.Identity.IsAuthenticated == false) return;

            // 判断是否Form验证方式
            if (request.User.Identity is FormsIdentity == false) return;

            // 获取用户标识
            var user_identity = (FormsIdentity)request.User.Identity;

            // 获取用户数据
            var user_data = user_identity.Ticket.UserData;

            // 获取角色数组
            var roles = user_data.Split(',');

            // 重新初始化GeneralPrincipal对象
            HttpContext.Current.User = new GenericPrincipal(user_identity, roles);

        }

        void Application_AuthorizeRequest(object sender, EventArgs e)
        {

        }
    }
}