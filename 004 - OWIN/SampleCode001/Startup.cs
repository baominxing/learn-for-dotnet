using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI.WebControls;
using Owin;
using SampleCode001.Middlewares;

namespace SampleCode001
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use<CacheMiddleware>();

            // 这段代码演示如何将中间件内容插入到管道里
            app.Use<TimerMiddleware>();

            // 这段代码演示如何将中间件内容插入到管道里
            app.Run(context =>
            {
                context.Response.ContentType = "text/plain";

                return context.Response.WriteAsync("Hello World!");
            });

        }
    }
}