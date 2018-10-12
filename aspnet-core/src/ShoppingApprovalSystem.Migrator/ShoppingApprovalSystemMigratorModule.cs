using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ShoppingApprovalSystem.Configuration;
using ShoppingApprovalSystem.EntityFrameworkCore;
using ShoppingApprovalSystem.Migrator.DependencyInjection;

namespace ShoppingApprovalSystem.Migrator
{
    [DependsOn(typeof(ShoppingApprovalSystemEntityFrameworkModule))]
    public class ShoppingApprovalSystemMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public ShoppingApprovalSystemMigratorModule(ShoppingApprovalSystemEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(ShoppingApprovalSystemMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                ShoppingApprovalSystemConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ShoppingApprovalSystemMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
