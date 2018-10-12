using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApprovalSystem.Users
{
    public class UserPagedResultRequestDto: PagedResultRequestDto
    {
        public virtual string UserName { get; set; }
    }
}
