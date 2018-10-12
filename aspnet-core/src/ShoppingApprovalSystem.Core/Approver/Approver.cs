using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApprovalSystem.Approver
{
    public class Approver : Entity, IHasCreationTime, IHasDeletionTime, IHasModificationTime, ICreationAudited
    {
        public int UserId { get; set; }
        public int ApproverId { get; set; }

        public DateTime CreationTime { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? CreatorUserId { get; set; }
    }
}
