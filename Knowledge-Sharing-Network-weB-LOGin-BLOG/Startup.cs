using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Knowledge_Sharing_Network_weB_LOGin_BLOG
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
            services.AddControllersWithViews(); //TODO : Service Mvc metodu sayesinde Global yetkilendirme servisi oluþturuldu. 

            //TODO :  services.AddSession(); //TODO : Oturum ekleme Login Controllerde yaptýðýmýz AllowAnonymous yetkinliðini doðru kullanmak için

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddMvc(); //TODO : Return url metodu. Sayfada eriþime izin verilmeyen alana týklandýðýnda login sayfasýna default yönlendirme yapmak için aþaðýdaki bloklarý da yazdýk.
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
                {
                    x.LoginPath = "/Login/Index";
                }
            );

            services.AddSingleton<IBlogService>(new BlogManager(new EfBlogDal()));
            services.AddSingleton<IAdministratorService>(new AdministratorManager(new EfAdministratorDal()));
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

            app.UseStatusCodePagesWithReExecute("/ErrorPages/ErrorNotFoundPage", "?code={0}"); // TODO : Kendi 404 sayfamýzý oluþturmak için konfigürasyon metodu

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //TODO app.UseSession(); //TODO : Authorize metodunun çalýþmasý izin verilen sýnýflarýn açýlmasý için bu metodu kullan demeliyiz.

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //TODO : Admin katmaný farklý klasör içersinde olduðu için yeniden route belirlemek gerekti bunun için MapAreaControllerRoute yapýsýný kullandým. Yeni route var olanýn altýna yapýþtýrdýðým için hatalar devam etti ve üste yapýþtýrdým denedim çalýþtý.
                endpoints.MapAreaControllerRoute(
                    name: "Administrator",
                    areaName: "Administrator",
                    pattern: "/Administrator/{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                //TODO : ScaffoldingReadMe sayfasýnda yeni route oluþturmamýz söyleniyor.
            });
        }
    }
}
