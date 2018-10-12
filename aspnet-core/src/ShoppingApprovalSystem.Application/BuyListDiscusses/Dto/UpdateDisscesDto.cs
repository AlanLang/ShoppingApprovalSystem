using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApprovalSystem.BuyListDiscusses.Dto
{
    public class UpdateDisscesDto : EntityDto<int>
    {
        public int BuyListId { get; set; }

        public bool IsAgree { get; set; }

        public string Discuss { get; set; }

    }
}
