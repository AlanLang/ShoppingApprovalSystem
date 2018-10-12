using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace ShoppingApprovalSystem.Controllers
{
    public abstract class ShoppingApprovalSystemControllerBase: AbpController
    {
        protected ShoppingApprovalSystemControllerBase()
        {
            LocalizationSourceName = ShoppingApprovalSystemConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
