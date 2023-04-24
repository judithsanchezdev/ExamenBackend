

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using WsApiexamen.Domain.Catalog;
using WsApiexamen.Repository;

namespace WsApiexamen
{
    public class Startup
    {
        public IConfiguration configRoot
        {
            get;
        }
        public Startup(IConfiguration configuration)
        {
            configRoot = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpClient();
            services.AddCors();

            services.AddDbContext<clsExamenDBContext>(options =>
                options.UseSqlServer(configRoot["ConnectionStrings:ExamenConnection"])
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                // Desarrollo
                .EnableSensitiveDataLogging(true));

            services.AddRazorPages();
            services.AddScoped<IExamenDomain, ExamenDomain>();
            services.AddScoped<IExamenRepository, ExamenRepository>();
  
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            app.Run();
        }
    }
}
