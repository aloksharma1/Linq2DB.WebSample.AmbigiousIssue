using Linq2DB.WebSample.AmbigiousIssue.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linq2DB.WebSample.AmbigiousIssue.Domain.Common
{
    public class BaseEntity : IBaseEntity
    {
        public virtual long Id { get; set; }
        public DateTimeOffset DateCreated { get; set; }=DateTimeOffset.UtcNow;
        public DateTimeOffset DateModified { get; set; } = DateTimeOffset.UtcNow;
        public bool IsActive { get; set; } = true;
    }
}
