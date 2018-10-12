using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApprovalSystem.Approver.Dto
{
    public class ApproverPageResultRequestDto : PagedResultRequestDto
    {
        public int id { get; set; }
    }
}
