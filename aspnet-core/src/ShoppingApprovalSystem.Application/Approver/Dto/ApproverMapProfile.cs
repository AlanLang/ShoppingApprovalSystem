using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApprovalSystem.Approver.Dto
{
    public class ApproverMapProfile : Profile
    {
        public ApproverMapProfile()
        {
            CreateMap<CreatApproverDto, Approver>();
            CreateMap<ApproverDto, Approver>();
            CreateMap<Approver, ApproverDto>();
        }
    }
}
