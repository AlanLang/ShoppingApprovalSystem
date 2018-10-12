using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApprovalSystem.BuyListDiscusses.Dto
{
    public class CreatDisscuesDto
    {
        public int BuyListId { get; set; }

        public bool IsAgree { get; set; }

        public string Discuss { get; set; }
    }
}
