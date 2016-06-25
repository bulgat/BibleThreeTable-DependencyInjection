using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ThreeBook.Startup))]
namespace ThreeBook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
