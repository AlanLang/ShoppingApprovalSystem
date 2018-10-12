using System.Threading.Tasks;
using Abp.Application.Services;
using ShoppingApprovalSystem.Authorization.Accounts.Dto;

namespace ShoppingApprovalSystem.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
