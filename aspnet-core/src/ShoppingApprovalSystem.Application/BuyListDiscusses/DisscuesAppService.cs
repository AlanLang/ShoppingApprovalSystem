using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using ShoppingApprovalSystem.Authorization.Users;
using ShoppingApprovalSystem.BuyList;
using ShoppingApprovalSystem.BuyListDiscusses.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApprovalSystem.BuyListDiscusses
{
    public class DisscuesAppService : AsyncCrudAppService<BuyListDiscuss, DisscuesDto, int, DisscuesResuleRequestDto, CreatDisscuesDto, UpdateDisscesDto>
    {
        private readonly UserManager _userManager;
        private IRepository<User, long> _userRepository;
        private IRepository<BuyList.BuyList, int> _buyRepository;
        private IRepository<Approver.Approver, int> _approverRepository;
        public DisscuesAppService(
            IRepository<BuyListDiscuss, int> repository,
            UserManager userManager,
            IRepository<User, long> userRepository,
            IRepository<BuyList.BuyList, int> buyRepository,
            IRepository<Approver.Approver, int> approverRepository
            ) : base(repository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _buyRepository = buyRepository;
            _approverRepository = approverRepository;
        }

        public override Task<DisscuesDto> Create(CreatDisscuesDto input)
        {
            if (input.IsAgree)
            {
                var buy = _buyRepository.GetAllList(m => m.Id == input.BuyListId).FirstOrDefault();
                var list = _approverRepository.GetAllList(m => m.UserId == buy.CreatorUserId);
                var users = _userRepository.GetAllList(m => list.Where(n => n.ApproverId == m.Id).Any());
                var aggres = Repository.GetAllList(m => users.Where(n => n.Id == m.CreatorUserId).Any()).Where(m => m.IsAgree && m.BuyListId == input.BuyListId).ToList();
                if (aggres.Count == users.Count - 1)
                {
                    buy.BuyState = 3;
                }
            }
            return base.Create(input);
        }

        public override async Task<PagedResultDto<DisscuesDto>> GetAll(DisscuesResuleRequestDto input)
        {
            // var v = Repository.GetAll().Join(_userRepository.GetAll(), a => a.BuyListId, b => b.Id);
            var disscues = await Repository.GetAllListAsync(m=>m.BuyListId == input.id);
            var disccuesDto = ObjectMapper.Map<List<DisscuesDto>>(disscues);
            foreach (var item in disccuesDto)
            {
                var user = _userManager.FindByIdAsync(item.CreatorUserId.ToString());
                item.Name = user.Result.Surname + user.Result.Name;
                item.UserName = user.Result.UserName;
            }
            return new PagedResultDto<DisscuesDto>(disccuesDto.Count,disccuesDto);
        }
    }
}
