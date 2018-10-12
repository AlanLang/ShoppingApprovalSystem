using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using ShoppingApprovalSystem.EntityFrameworkCore.Seed;

namespace ShoppingApprovalSystem.EntityFrameworkCore
{
    [DependsOn(
        typeof(ShoppingApprovalSystemCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class ShoppingApprovalSystemEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<ShoppingApprovalSystemDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        ShoppingApprovalSystemDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        ShoppingApprovalSystemDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ShoppingApprovalSystemEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
