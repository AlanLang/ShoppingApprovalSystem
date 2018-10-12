using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingApprovalSystem.BuyList.Dto
{
    public class CreatBuyListDto
    {
        [MaxLength(30)]
        [Required]
        public string BuyName { get; set; }
	    [Required]
        public decimal BuyPrice { get; set; }

        [MaxLength(50)]
        public string BuyUrl { get; set; }

        [MaxLength(30)]
        [Required]
        public string BuyTypeName { get; set; }

        [MaxLength(30)]
        [Required]
        public string BuyLevel { get; set; }

        [MaxLength(30)]
        [Required]
        public string BuyTime { get; set; }

        [MaxLength(30)]
        public string BuyAuthor { get; set; }

        /// <summary>
        /// 0 新增，1审核中，2 被驳货，3已通过，4不买了，5已购买
        /// </summary>
        public int BuyState { get; set; }

        [MaxLength(90)]
        public string BuyDesc { get; set; }
    }
}
