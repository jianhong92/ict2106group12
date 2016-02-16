using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(group12web.Startup))]
namespace group12web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
