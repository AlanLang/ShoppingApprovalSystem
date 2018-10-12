using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ShoppingApprovalSystem.MultiTenancy;

namespace ShoppingApprovalSystem.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
