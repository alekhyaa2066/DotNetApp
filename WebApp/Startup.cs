using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LTI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LTI.Core;
using Microsoft.AspNetCore.Http;

namespace WebApp
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

            services.AddDbContext<LTIDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("LTIDb"))
            );

            //services.AddSingleton<IEmployeeData, EmployeesData>(); //without connection of database for dev and testing
            services.AddScoped<IEmployeeData, SqlEmployeeData>(); //with sql server connection
            //services.AddSingleton<IProjectData, ProjectsData>(); 
            services.AddScoped<IProjectData, SqlProjectData>();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.Use(HelloMiddleWare);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseNodeModules(env);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }

        private RequestDelegate HelloMiddleWare(RequestDelegate next)
        {
            return async ctx => {
                if (ctx.Request.Path.StartsWithSegments("/hello")){
                    await ctx.Response.WriteAsync("Hello Middleware");
                }

                else
                {
                    await next(ctx);
                }
                    
            };
        }
    }
}
