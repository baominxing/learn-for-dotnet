using System.Web.Http;
using Owin;

namespace SampleCode001
{
    internal class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            // 创建 Web API 的配置
            var config = new HttpConfiguration();
            // 启用标记路由
            config.MapHttpAttributeRoutes();
            // 默认的 Web API 路由
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            // 将路由配置附加到 appBuilder
            appBuilder.UseWebApi(config);
        }
    }
}
