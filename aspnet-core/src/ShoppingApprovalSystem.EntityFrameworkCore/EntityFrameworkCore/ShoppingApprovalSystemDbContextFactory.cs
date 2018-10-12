using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ShoppingApprovalSystem.Configuration;
using ShoppingApprovalSystem.Web;

namespace ShoppingApprovalSystem.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ShoppingApprovalSystemDbContextFactory : IDesignTimeDbContextFactory<ShoppingApprovalSystemDbContext>
    {
        public ShoppingApprovalSystemDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ShoppingApprovalSystemDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ShoppingApprovalSystemDbContextConfigurer.Configure(builder, configuration.GetConnectionString(ShoppingApprovalSystemConsts.ConnectionStringName));

            return new ShoppingApprovalSystemDbContext(builder.Options);
        }
    }
}
