using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ShoppingApprovalSystem.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingApprovalSystem.BuyList
{
    public class BuyListDiscuss : Entity, IHasCreationTime, IHasDeletionTime, IHasModificationTime, ICreationAudited
    {
        public int BuyListId { get; set; }

        public bool IsAgree { get; set; }

        [MaxLength(300)]
        public string Discuss { get; set; }

        public DateTime CreationTime { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? CreatorUserId { get; set; }

    }
}
