using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sem3_backend.Startup))]
namespace Sem3_backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
