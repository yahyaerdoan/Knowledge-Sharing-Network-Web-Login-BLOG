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
            services.AddControllersWithViews(); //TODO : Service Mvc metodu sayesinde Global yetkilendirme servisi olu�turuldu. 

            //TODO :  services.AddSession(); //TODO : Oturum ekleme Login Controllerde yapt���m�z AllowAnonymous yetkinli�ini do�ru kullanmak i�in

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddMvc(); //TODO : Return url metodu. Sayfada eri�ime izin verilmeyen alana t�kland���nda login sayfas�na default y�nlendirme yapmak i�in a�a��daki bloklar� da yazd�k.
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

            app.UseStatusCodePagesWithReExecute("/ErrorPages/ErrorNotFoundPage", "?code={0}"); // TODO : Kendi 404 sayfam�z� olu�turmak i�in konfig�rasyon metodu

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //TODO app.UseSession(); //TODO : Authorize metodunun �al��mas� izin verilen s�n�flar�n a��lmas� i�in bu metodu kullan demeliyiz.

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //TODO : Admin katman� farkl� klas�r i�ersinde oldu�u i�in yeniden route belirlemek gerekti bunun i�in MapAreaControllerRoute yap�s�n� kulland�m. Yeni route var olan�n alt�na yap��t�rd���m i�in hatalar devam etti ve �ste yap��t�rd�m denedim �al��t�.
                endpoints.MapAreaControllerRoute(
                    name: "Administrator",
                    areaName: "Administrator",
                    pattern: "/Administrator/{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                //TODO : ScaffoldingReadMe sayfas�nda yeni route olu�turmam�z s�yleniyor.
            });
        }
    }
}
