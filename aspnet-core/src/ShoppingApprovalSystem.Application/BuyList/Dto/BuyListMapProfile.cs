using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApprovalSystem.BuyList.Dto
{
    public class BuyListMapProfile: Profile
    {
        public BuyListMapProfile()
        {
            CreateMap<CreatBuyListDto, BuyList>();
            CreateMap<BuyListDto, BuyList>();
            CreateMap<UpdateBuyListDto, BuyList>();
            CreateMap<BuyList, BuyListDto>().ForMember(x => x.BuyStateMsg, opt => {
                opt.ResolveUsing<NoteToNoteDtoResolver>();
            });
        }
    }

    public class NoteToNoteDtoResolver : IValueResolver<BuyList, BuyListDto, string>
    {
        public string Resolve(BuyList source, BuyListDto destination, string destMember, ResolutionContext context)
        {
            switch (source.BuyState)
            {
                case 0:return "新增";
                case 1:return "审核中";
                case 2:return "被驳回";
                case 3:return "已通过";
                case 4:return "不买了";
                case 5:return "已购买";
                default:
                    return "未定义";
            }
        }
    }
}
