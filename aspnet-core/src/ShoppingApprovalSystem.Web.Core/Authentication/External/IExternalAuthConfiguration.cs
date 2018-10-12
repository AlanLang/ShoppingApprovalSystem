using System.Collections.Generic;

namespace ShoppingApprovalSystem.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
