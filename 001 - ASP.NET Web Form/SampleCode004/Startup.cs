using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SampleCode004.Startup))]
namespace SampleCode004
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
