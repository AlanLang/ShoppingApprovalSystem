using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApprovalSystem.Approver.Dto
{
    public class ApproverDto : EntityDto<int>
    {
        public int UserId { get; set; }
        public int ApproverId { get; set; }
    }
}
