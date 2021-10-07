using Linq2DB.WebSample.AmbigiousIssue.Abstractions;
using Linq2DB.WebSample.AmbigiousIssue.Extensions;
using Linq2DB.WebSample.AmbigiousIssue.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Linq2DB.WebSample.AmbigiousIssue
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            configRoot = builder.Build();            
            _env = env;
        }
        public IServiceCollection _services { get; private set; }

        private readonly IConfigurationRoot configRoot;
        private readonly IWebHostEnvironment _env;
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSession();
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<AppDbContext>());
            services.AddDbContext<AppDbContext>(options =>
                  options.UseSqlServer(Configuration.GetSection("DBProviders:0:ConnectionString").Value
               ,
               b => {
                   b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
                   b.EnableRetryOnFailure();
               }));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<AppDbContext>());
            services.Add(new ServiceDescriptor(typeof(IRepository<,>), typeof(Repository<,>), ServiceLifetime.Scoped));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            dbContext.Database.EnsureCreated();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                     name: "default",
                     pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
