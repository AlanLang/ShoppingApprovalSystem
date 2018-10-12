using Abp.Application.Services;
using ShoppingApprovalSystem.BuyList.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApprovalSystem.BuyList
{
    public interface IBuyAppService : IAsyncCrudAppService<Dto.BuyListDto, int, BuyPageResultRequestDto, CreatBuyListDto, UpdateBuyListDto>
    {
    }
}
