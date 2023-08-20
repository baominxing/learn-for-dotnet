using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SampleCode001
{
    /// <summary>
    /// 自定义HttpHandler
    /// 
    /// 我们可以从请求级出发，避开默认机制，动态响应 .log（自定义）后缀的请求
    /// </summary>
    public class CustomHttpHandler : IHttpHandler
    {
        public bool IsReusable => true;

        /// <summary>
        /// 处理请求
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            context.Response.Write("这个从自定义Handler处理输出");
        }
    }
}