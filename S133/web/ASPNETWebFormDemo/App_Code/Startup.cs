using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPNETWebFormDemo.Startup))]
namespace ASPNETWebFormDemo
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
