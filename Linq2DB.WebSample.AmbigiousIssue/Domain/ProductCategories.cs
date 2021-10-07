using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Linq2DB.WebSample.AmbigiousIssue.Domain
{
    [Table("ProductCategories")]
    public class ProductCategories : Common.CommonCategories
    {
    }
}
