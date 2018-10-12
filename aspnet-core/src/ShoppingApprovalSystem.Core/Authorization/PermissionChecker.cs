using Abp.Authorization;
using ShoppingApprovalSystem.Authorization.Roles;
using ShoppingApprovalSystem.Authorization.Users;

namespace ShoppingApprovalSystem.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
