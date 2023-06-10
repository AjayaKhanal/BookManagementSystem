using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BookManagementSystem.Authorization;

namespace BookManagementSystem
{
    [DependsOn(
        typeof(BookManagementSystemCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class BookManagementSystemApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<BookManagementSystemAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(BookManagementSystemApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
