using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using ShoppingApprovalSystem.Approver.Dto;
using ShoppingApprovalSystem.Authorization;
using ShoppingApprovalSystem.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApprovalSystem.Approver
{
    [AbpAuthorize(PermissionNames.Pages_Users)]
    public class ApproverAppService : AsyncCrudAppService<Approver, ApproverDto, int, ApproverPageResultRequestDto, CreatApproverDto, ApproverDto>
    {
        private readonly UserManager _userManager;
        private IRepository<User, long> _userRepository;
        public ApproverAppService(
            IRepository<Approver, int> repository,
            UserManager userManager,
            IRepository<User, long> userRepository
            ) : base(repository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }
        /// <summary>
        /// 获取指定用户的审批人
        /// </summary>
        /// <returns></returns>
        public async Task<ListResultDto<Users.Dto.UserDto>> GetUserApprovers(int id)
        {
            var list = await Repository.GetAllListAsync(m => m.UserId == id);
            var users = await _userRepository.GetAllListAsync(m => list.Where(n => n.ApproverId == m.Id).Any());
            return new ListResultDto<Users.Dto.UserDto>(ObjectMapper.Map<List<Users.Dto.UserDto>>(users));
        }

        public void Remove(CreatApproverDto input)
        {
            var approver =  Repository.GetAll().Where(m => m.UserId == input.UserId && m.ApproverId == input.ApproverId).FirstOrDefault();
            Repository.Delete(approver);
        }

        public override async Task<ApproverDto> Create(CreatApproverDto input)
        {
            var approvers = await Repository.GetAllListAsync(m => m.ApproverId == input.ApproverId && m.UserId == input.UserId);
            if (approvers.Count == 0)
            {
                return MapToEntityDto(Repository.Insert(MapToEntity(input)));
            }
            else {
                return MapToEntityDto(approvers.FirstOrDefault());
            }
        }
    }
}
