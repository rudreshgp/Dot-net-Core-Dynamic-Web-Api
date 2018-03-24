using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DynamicProject.BusinesManager;
using DynamicProject.BusinesManagerContracts;
using DynamicProject.BusinesService;
using DynamicProject.Repository;
using DynamicProject.Repository.Helper;
using DynamicProject.RepositoryContracts;
using DynamicProject.ServiceHost.ConfigurationHelpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DynamicProject.ServiceHost
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().ConfigureApplicationPartManager(
                manager=>{
                    //Register custom controller provider
                    manager.FeatureProviders.Add(new CustomApplicationFeatureProvider());

                    manager.ApplicationParts.Add(new AssemblyPart(typeof(DynamicProject.BusinesService.Empty).Assembly));
                });
                var conString = Configuration.GetConnectionString("DefaultConnection");
                services.AddDbContext<ApplicationContext>(options=>options.UseSqlServer(conString));
                services.AddScoped<IDbContextFactory<IDomainModelContext>,DbContextFactory>();
                services.AddScoped(typeof(ICrudRepository<>),typeof(CrudRepository<>));
                services.AddScoped(typeof(IBusinessManager<,>),typeof(BusinessManager<,>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
