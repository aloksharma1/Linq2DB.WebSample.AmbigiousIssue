using System;
using System.Collections.Generic;
using System.Text;

namespace Linq2DB.WebSample.AmbigiousIssue.Abstractions
{
    public interface IBaseEntity
    {
        public long Id { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateModified { get; set; }
        public bool IsActive { get; set; }
    }
}
