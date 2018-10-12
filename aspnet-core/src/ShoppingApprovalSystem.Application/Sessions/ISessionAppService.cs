using System.Threading.Tasks;
using Abp.Application.Services;
using ShoppingApprovalSystem.Sessions.Dto;

namespace ShoppingApprovalSystem.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
