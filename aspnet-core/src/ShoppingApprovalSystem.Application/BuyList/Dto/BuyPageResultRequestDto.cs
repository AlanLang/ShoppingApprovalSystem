using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApprovalSystem.BuyList.Dto
{
    public class BuyPageResultRequestDto: PagedResultRequestDto
    {
        public virtual string search { get; set; }
        public virtual int type { get; set; }
    }
}
