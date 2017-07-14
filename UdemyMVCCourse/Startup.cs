using AutoMapper;
using Microsoft.Owin;
using Owin;
using UdemyMVCCourse.DTOs;
using UdemyMVCCourse.Models;

[assembly: OwinStartupAttribute(typeof(UdemyMVCCourse.Startup))]
namespace UdemyMVCCourse
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
