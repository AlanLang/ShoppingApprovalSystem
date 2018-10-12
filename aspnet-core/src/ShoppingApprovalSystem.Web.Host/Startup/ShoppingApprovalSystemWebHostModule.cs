using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ShoppingApprovalSystem.Configuration;

namespace ShoppingApprovalSystem.Web.Host.Startup
{
    [DependsOn(
       typeof(ShoppingApprovalSystemWebCoreModule))]
    public class ShoppingApprovalSystemWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ShoppingApprovalSystemWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ShoppingApprovalSystemWebHostModule).GetAssembly());
        }
    }
}
