using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApprovalSystem.BuyListDiscusses.Dto
{
    public class DisscuesDto : EntityDto<int>
    {
        public int BuyListId { get; set; }

        public bool IsAgree { get; set; }

        public string Discuss { get; set; }

        public DateTime CreationTime { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public long? CreatorUserId { get; set; }
    }
}
