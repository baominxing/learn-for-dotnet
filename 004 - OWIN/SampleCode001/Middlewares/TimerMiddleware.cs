using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin;

namespace SampleCode001.Middlewares
{
    public class TimerMiddleware : OwinMiddleware
    {
        public TimerMiddleware(OwinMiddleware next) : base(next)
        {
        }

        public override Task Invoke(IOwinContext context)
        {
            var response = "It is " + DateTime.Now + Environment.NewLine;

            context.Response.Write(response);

            if (context.Environment.ContainsKey("caching.addToCache"))//这里直接从OWIN管道的字典中，检查是否有add cache, 如果存在，就将输出内容缓存到cache中，过期时间为10分钟。
            {
                // 将内容缓存
                var cacheAction = context.Environment["caching.addToCache"] as Action<IOwinContext, string, TimeSpan>;

                cacheAction(context, response, TimeSpan.FromSeconds(10));
            }
            // 这里返回，直接短路关掉，后面的中间件不再被执行
            // return Task.CompletedTask;

            return Next.Invoke(context);
        }
    }
}