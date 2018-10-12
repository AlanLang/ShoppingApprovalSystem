using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ShoppingApprovalSystem.MultiTenancy.Dto;

namespace ShoppingApprovalSystem.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
