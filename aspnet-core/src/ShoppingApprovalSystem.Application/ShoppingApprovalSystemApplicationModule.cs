using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ShoppingApprovalSystem.Authorization;

namespace ShoppingApprovalSystem
{
    [DependsOn(
        typeof(ShoppingApprovalSystemCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ShoppingApprovalSystemApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ShoppingApprovalSystemAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ShoppingApprovalSystemApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
