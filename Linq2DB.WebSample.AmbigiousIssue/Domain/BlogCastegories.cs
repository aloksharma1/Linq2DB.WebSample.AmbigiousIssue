using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Linq2DB.WebSample.AmbigiousIssue.Domain
{
    [Table("BlogCategories")]
    public class BlogCategories: Common.CommonCategories
    {
    }
}
