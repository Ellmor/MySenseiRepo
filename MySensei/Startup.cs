using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MySensei.Startup))]
namespace MySensei
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
