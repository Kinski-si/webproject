using System;

namespace Website.Domain.Contracts.Models
{
    public class User : ModelBase
    {
        public virtual string UserName { get; set; }

        public virtual string Email { get; set; }

        public virtual string PhoneNumber { get; set; }

        public virtual DateTimeOffset? LockoutEnd { get; set; }

        public virtual bool LockoutEnabled { get; set; }

        public virtual int AccessFailedCount { get; set; }
    }
}