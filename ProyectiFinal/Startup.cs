using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProyectiFinal.Startup))]
namespace ProyectiFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
