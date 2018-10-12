using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ShoppingApprovalSystem.Roles.Dto;
using ShoppingApprovalSystem.Users.Dto;

namespace ShoppingApprovalSystem.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, UserPagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
