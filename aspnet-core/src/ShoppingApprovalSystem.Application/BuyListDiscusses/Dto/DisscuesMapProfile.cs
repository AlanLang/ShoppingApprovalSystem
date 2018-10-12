using AutoMapper;
using ShoppingApprovalSystem.Approver.Dto;
using ShoppingApprovalSystem.BuyList;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApprovalSystem.BuyListDiscusses.Dto
{
    public class DisscuesMapProfile : Profile
    {
        public DisscuesMapProfile()
        {
            CreateMap<CreatDisscuesDto, BuyListDiscuss>();
            CreateMap<DisscuesDto, BuyListDiscuss>();
            CreateMap<UpdateDisscesDto, BuyListDiscuss>();
            CreateMap<BuyListDiscuss, DisscuesDto>();
        }

    }
}
