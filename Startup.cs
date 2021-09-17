using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AskAndTell.Startup))]
namespace AskAndTell
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
