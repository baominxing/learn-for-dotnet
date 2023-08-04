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
    }
}