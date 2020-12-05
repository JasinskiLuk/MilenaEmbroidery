using Dapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MilenaEmbroidery.DbServices.General;
using MilenaEmbroidery.DbServices.Shop;
using MilenaEmbroidery.IServices.General;
using MilenaEmbroidery.IServices.Shop;
using System;
using System.Data;

namespace MilenaEmbroidery.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
                    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.AddSession();

            services.AddScoped<IProductService, DbProductService>();
            services.AddScoped<IOrderService, DbOrderService>();
            services.AddScoped<IOrderListService, DbOrderListService>();
            services.AddScoped<IOrderStatusService, DbOrderStatusService>();
            services.AddScoped<IUserService, DbUserService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false)
                .Build();

            SqlMapper.AddTypeMap(typeof(DateTime), DbType.DateTime2);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Product}/{action=Index}/{id?}");

                //Endpoint for Areas
                /*
                endpoints.MapControllerRoute(
                   name: "MyAreas",
                   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                */
            });
        }
    }
}
