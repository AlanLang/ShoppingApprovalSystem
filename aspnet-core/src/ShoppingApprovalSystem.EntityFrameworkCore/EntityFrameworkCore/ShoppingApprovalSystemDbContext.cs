using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ShoppingApprovalSystem.Authorization.Roles;
using ShoppingApprovalSystem.Authorization.Users;
using ShoppingApprovalSystem.MultiTenancy;

namespace ShoppingApprovalSystem.EntityFrameworkCore
{
    public class ShoppingApprovalSystemDbContext : AbpZeroDbContext<Tenant, Role, User, ShoppingApprovalSystemDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public ShoppingApprovalSystemDbContext(DbContextOptions<ShoppingApprovalSystemDbContext> options)
            : base(options)
        {

        }
        public DbSet<BuyList.BuyList> buyList { get; set; }
        public DbSet<Approver.Approver> approvers { get; set; }
        public DbSet<BuyList.BuyListDiscuss> buyListDiscusses { get; set; }
    }
}
