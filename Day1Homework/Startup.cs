using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Day1Homework.Startup))]
namespace Day1Homework
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
