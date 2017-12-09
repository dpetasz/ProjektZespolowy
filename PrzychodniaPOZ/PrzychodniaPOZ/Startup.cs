using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrzychodniaPOZ.Startup))]
namespace PrzychodniaPOZ
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
