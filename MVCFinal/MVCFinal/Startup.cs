using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCFinal.Startup))]
namespace MVCFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
