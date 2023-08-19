
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleCode001
{
    public class CustomHttpModule : IHttpModule
    {
        public event EventHandler CustomHttpModuleHandler;

        public void Dispose()
        {
            Console.WriteLine("This is CustomHttpModule.Dispose");
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += (s, e) =>
            {
                this.CustomHttpModuleHandler?.Invoke(context, null);
            };

            //为每一个事件，都注册了一个动作，向客户端输出信息
            context.AcquireRequestState += (s, e) => context.Response.Write(string.Format("<h2 style='color:#00f'>来自CustomHttpModule 的处理，{0}请求到达 {1}</h2><hr>", DateTime.Now.ToString(), "AcquireRequestState        "));
            context.AuthenticateRequest += (s, e) => context.Response.Write(string.Format("<h2 style='color:#00f'>来自CustomHttpModule 的处理，{0}请求到达 {1}</h2><hr>", DateTime.Now.ToString(), "AuthenticateRequest        "));
            context.AuthorizeRequest += (s, e) => context.Response.Write(string.Format("<h2 style='color:#00f'>来自CustomHttpModule 的处理，{0}请求到达 {1}</h2><hr>", DateTime.Now.ToString(), "AuthorizeRequest           "));
            context.BeginRequest += (s, e) => context.Response.Write(string.Format("<h2 style='color:#00f'>来自CustomHttpModule 的处理，{0}请求到达 {1}</h2><hr>", DateTime.Now.ToString(), "BeginRequest               "));
            //context.Disposed += (s, e) => context.Response.Write(string.Format("<h2 style='color:#00f'>来自CustomHttpModule 的处理，{0}请求到达 {1}</h2><hr>", DateTime.Now.ToString(), "Disposed                   "));
            context.EndRequest += (s, e) => context.Response.Write(string.Format("<h2 style='color:#00f'>来自CustomHttpModule 的处理，{0}请求到达 {1}</h2><hr>", DateTime.Now.ToString(), "EndRequest                 "));
            context.Error += (s, e) => context.Response.Write(string.Format("<h2 style='color:#00f'>来自CustomHttpModule 的处理，{0}请求到达 {1}</h2><hr>", DateTime.Now.ToString(), "Error                      "));
            context.LogRequest += (s, e) => context.Response.Write(string.Format("<h2 style='color:#00f'>来自CustomHttpModule 的处理，{0}请求到达 {1}</h2><hr>", DateTime.Now.ToString(), "LogRequest                 "));
            context.MapRequestHandler += (s, e) => context.Response.Write(string.Format("<h2 style='color:#00f'>来自CustomHttpModule 的处理，{0}请求到达 {1}</h2><hr>", DateTime.Now.ToString(), "MapRequestHandler          "));
            context.PostAcquireRequestState += (s, e) => context.Response.Write(string.Format("<h2 style='color:#00f'>来自CustomHttpModule 的处理，{0}请求到达 {1}</h2><hr>", DateTime.Now.ToString(), "PostAcquireRequestState    "));
            context.PostAuthenticateRequest += (s, e) => context.Response.Write(string.Format("<h2 style='color:#00f'>来自CustomHttpModule 的处理，{0}请求到达 {1}</h2><hr>", DateTime.Now.ToString(), "PostAuthenticateRequest    "));
            context.PostAuthorizeRequest += (s, e) => context.Response.Write(string.Format("<h2 style='color:#00f'>来自CustomHttpModule 的处理，{0}请求到达 {1}</h2><hr>", DateTime.Now.ToString(), "PostAuthorizeRequest       "));
            context.PostLogRequest += (s, e) => context.Response.Write(string.Format("<h2 style='color:#00f'>来自CustomHttpModule 的处理，{0}请求到达 {1}</h2><hr>", DateTime.Now.ToString(), "PostLogRequest             "));
            context.PostMapRequestHandler += (s, e) => context.Response.Write(string.Format("<h2 style='color:#00f'>来自CustomHttpModule 的处理，{0}请求到达 {1}</h2><hr>", DateTime.Now.ToString(), "PostMapRequestHandler      "));
            context.PostReleaseRequestState += (s, e) => context.Response.Write(string.Format("<h2 style='color:#00f'>来自CustomHttpModule 的处理，{0}请求到达 {1}</h2><hr>", DateTime.Now.ToString(), "PostReleaseRequestState    "));
            context.PostRequestHandlerExecute += (s, e) => context.Response.Write(string.Format("<h2 style='color:#00f'>来自CustomHttpModule 的处理，{0}请求到达 {1}</h2><hr>", DateTime.Now.ToString(), "PostRequestHandlerExecute  "));
            context.PostResolveRequestCache += (s, e) => context.Response.Write(string.Format("<h2 style='color:#00f'>来自CustomHttpModule 的处理，{0}请求到达 {1}</h2><hr>", DateTime.Now.ToString(), "PostResolveRequestCache    "));
            context.PostUpdateRequestCache += (s, e) => context.Response.Write(string.Format("<h2 style='color:#00f'>来自CustomHttpModule 的处理，{0}请求到达 {1}</h2><hr>", DateTime.Now.ToString(), "PostUpdateRequestCache     "));
            context.PreRequestHandlerExecute += (s, e) => context.Response.Write(string.Format("<h2 style='color:#00f'>来自CustomHttpModule 的处理，{0}请求到达 {1}</h2><hr>", DateTime.Now.ToString(), "PreRequestHandlerExecute   "));
            context.PreSendRequestContent += (s, e) => context.Response.Write(string.Format("<h2 style='color:#00f'>来自CustomHttpModule 的处理，{0}请求到达 {1}</h2><hr>", DateTime.Now.ToString(), "PreSendRequestContent      "));
            context.PreSendRequestHeaders += (s, e) => context.Response.Write(string.Format("<h2 style='color:#00f'>来自CustomHttpModule 的处理，{0}请求到达 {1}</h2><hr>", DateTime.Now.ToString(), "PreSendRequestHeaders      "));
            context.ReleaseRequestState += (s, e) => context.Response.Write(string.Format("<h2 style='color:#00f'>来自CustomHttpModule 的处理，{0}请求到达 {1}</h2><hr>", DateTime.Now.ToString(), "ReleaseRequestState        "));
            //context.RequestCompleted += (s, e) => context.Response.Write(string.Format("<h2 style='color:#00f'>来自CustomHttpModule 的处理，{0}请求到达 {1}</h2><hr>", DateTime.Now.ToString(), "RequestCompleted           "));
            context.ResolveRequestCache += (s, e) => context.Response.Write(string.Format("<h2 style='color:#00f'>来自CustomHttpModule 的处理，{0}请求到达 {1}</h2><hr>", DateTime.Now.ToString(), "ResolveRequestCache        "));
            context.UpdateRequestCache += (s, e) => context.Response.Write(string.Format("<h2 style='color:#00f'>来自CustomHttpModule 的处理，{0}请求到达 {1}</h2><hr>", DateTime.Now.ToString(), "UpdateRequestCache         "));
        }
    }
}