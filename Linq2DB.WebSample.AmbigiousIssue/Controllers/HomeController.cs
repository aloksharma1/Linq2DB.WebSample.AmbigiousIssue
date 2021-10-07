using Linq2DB.WebSample.AmbigiousIssue.Abstractions;
using Linq2DB.WebSample.AmbigiousIssue.Domain;
using Linq2DB.WebSample.AmbigiousIssue.Domain.Common;
using Linq2DB.WebSample.AmbigiousIssue.Persistence;
using LinqToDB.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linq2DB.WebSample.AmbigiousIssue.Controllers
{
    public class HomeController : Controller
    {
        public IRepository<BlogCategories,AppDbContext> Repository1 { get; set; }
        public IRepository<BlogCategories,AppDbContext> Repository2 { get; set; }
        public HomeController(IRepository<BlogCategories, AppDbContext> _repository1,
            IRepository<BlogCategories, AppDbContext> _repository2)
        {
            Repository1 = _repository1;
            Repository2 = _repository2;
        }
        public IActionResult Index()
        {
            var query1 = Repository1.Query().Where(x => x.IsActive == true).Select(x=>new SearchResults { 
                Id=""+x.Id,
                Title=x.CategoryName,
                DateCreated=x.DateCreated,
                DateModified=x.DateModified
            });
            var query2 = Repository2.Query().Where(x => x.IsActive == true).Select(x => new SearchResults
            {
                Id = "" + x.Id,
                Title = x.CategoryName,
                DateCreated = x.DateCreated,
                DateModified = x.DateModified
            });
            var finalResult = query1.Union(query2).ToLinqToDB();
            return Ok(finalResult.ToList());
        }
    }
}
