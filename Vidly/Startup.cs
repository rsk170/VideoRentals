using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Vidly.StartupOwin))]

namespace Vidly
{
    public partial class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            //AuthStartup.ConfigureAuth(app);
        }
    }
}
