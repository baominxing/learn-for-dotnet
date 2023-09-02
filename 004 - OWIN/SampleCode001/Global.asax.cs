using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace SampleCode001
{
    public class Global : HttpApplication
    {
        // How to hook OWIN pipelines into the normal Asp.Net route table side by side with other components.
        protected void Application_Start(object sender, EventArgs e)
        {
        }
    }
}