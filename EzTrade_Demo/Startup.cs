using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EzTrade_Demo.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EzTrade_Demo
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
            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            services.AddSingleton<DAL.CodeDAL>();
            services.AddSingleton<DAL.CodeDetailsDAL>();
            services.AddSingleton<DAL.UserDAL>();
            services.AddSingleton<BLL.CodeBLL>();
            services.AddSingleton<BLL.CodeDetailsBLL>();
            services.AddSingleton<BLL.UserBLL>();
            services.AddSignalR();

            services.AddOptions();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<NotiHub>("/notiHub");
                endpoints.MapHub<GroupHub>("/groupHub");
                endpoints.MapHub<CounterHub>("/counterHub");
                endpoints.MapHub<MessageHub>($"/{nameof(MessageHub)}");
                
            });

        }
    }
}
