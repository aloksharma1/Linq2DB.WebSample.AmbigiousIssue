using Linq2DB.WebSample.AmbigiousIssue.Abstractions;
using Linq2DB.WebSample.AmbigiousIssue.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Linq2DB.WebSample.AmbigiousIssue.Persistence
{
    public class AppDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<BlogCategories> BlogCastegories { get; set; }
        public DbSet<ProductCategories> ProductCategories { get; set; }
        public AppDbContext([NotNull] DbContextOptions<AppDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<BlogCategories>()
                .HasOne<BlogCategories>().WithMany().HasForeignKey(e => e.CategoryParentId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<BlogCategories>().HasData(new BlogCategories
            {
                CategoryName="Ef Core",                
            },
            new BlogCategories
            {
                CategoryName="LinqToDb"
            });

            modelBuilder.Entity<ProductCategories>()
                .HasOne<ProductCategories>().WithMany().HasForeignKey(e => e.CategoryParentId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProductCategories>().HasData(new ProductCategories
            {
                CategoryName = "Digital",
            },
            new ProductCategories
            {
                CategoryName = "Tangible"
            });

            base.OnModelCreating(modelBuilder); 
        }
    }
}
