using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ShoppingApprovalSystem.EntityFrameworkCore
{
    public static class ShoppingApprovalSystemDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ShoppingApprovalSystemDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
            //֧��sql2005,2008�ķ�ҳ
            builder.UseSqlServer(connectionString, b => b.UseRowNumberForPaging());
        }

        public static void Configure(DbContextOptionsBuilder<ShoppingApprovalSystemDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
            //֧��sql2005,2008�ķ�ҳ
            builder.UseSqlServer(connection, b => b.UseRowNumberForPaging());
        }
    }
}
