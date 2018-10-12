using Abp.Authorization.Users;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ShoppingApprovalSystem.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingApprovalSystem.BuyList
{
    public class BuyList: Entity, IHasCreationTime, IHasDeletionTime, IHasModificationTime, ICreationAudited
    {
        public BuyList()
        {

        }

        [MaxLength(30)]
        public string BuyName { get; set; }

        public decimal BuyPrice { get; set; }

        [MaxLength(50)]
        public string BuyUrl { get; set; }

        [MaxLength(30)]
        public string BuyTypeName { get; set; }

        [MaxLength(30)]
        public string BuyLevel { get; set; }

        [MaxLength(30)]
        public string BuyTime { get; set; }

        [MaxLength(30)]
        public string BuyAuthor { get; set; }

        /// <summary>
        /// 0 新增，1审核中，2 被驳回，3已通过，4不买了，5已购买
        /// </summary>
        public int BuyState { get; set; }

        [MaxLength(90)]
        public string BuyDesc { get; set; }

        public DateTime CreationTime { get ; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? CreatorUserId { get; set; }
    }
}
