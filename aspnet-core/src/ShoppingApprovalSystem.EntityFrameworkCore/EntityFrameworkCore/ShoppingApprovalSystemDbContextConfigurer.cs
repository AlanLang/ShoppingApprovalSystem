using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ShoppingApprovalSystem.EntityFrameworkCore
{
    public static class ShoppingApprovalSystemDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ShoppingApprovalSystemDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
            //支持sql2005,2008的分页
            builder.UseSqlServer(connectionString, b => b.UseRowNumberForPaging());
        }

        public static void Configure(DbContextOptionsBuilder<ShoppingApprovalSystemDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
            //支持sql2005,2008的分页
            builder.UseSqlServer(connection, b => b.UseRowNumberForPaging());
        }
    }
}
