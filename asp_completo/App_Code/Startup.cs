using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(temp.Startup))]
namespace temp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
