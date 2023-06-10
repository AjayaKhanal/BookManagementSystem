using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BookManagementSystem.Configuration;

namespace BookManagementSystem.Web.Host.Startup
{
    [DependsOn(
       typeof(BookManagementSystemWebCoreModule))]
    public class BookManagementSystemWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public BookManagementSystemWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BookManagementSystemWebHostModule).GetAssembly());
        }
    }
}
