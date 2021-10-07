using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linq2DB.WebSample.AmbigiousIssue.Domain.Common
{
    public class SearchResults
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTimeOffset? DateModified { get; set; }
        public DateTimeOffset? DateCreated { get; set; }
    }
}
