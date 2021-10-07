using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Linq2DB.WebSample.AmbigiousIssue.Domain.Common
{
    public class CommonCategories:BaseEntity
    {
        public new Guid Id { get; set; } = Guid.NewGuid();

        [StringLength(250)]
        public string CategoryName { get; set; }
        public Guid? CategoryParentId { get; set; }
    }
}
