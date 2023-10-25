using System.Globalization;
using GamingGroove.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;


namespace GamingGroove
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });            

            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

            builder.Services.AddDbContext<GamingGrooveDbContext>(
                options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                new MySqlServerVersion(new Version(8, 0, 34))) 
            );

            builder.Services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = ContextBoundObject => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => {

                    // options.AccessDeniedPath = "/Shared/AccessDenied";
                    // options.LoginPath = "/Usuarios/Login/";
                    options.AccessDeniedPath = "/AcessoNegadoPage";
                    options.LoginPath = "/AcessoNegadoPage";
                });

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "home",
                pattern: "{controller=HomePage}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "perfil",
                pattern: "PerfilPage/{user}",
                defaults: new { controller = "PerfilPage", action = "Index" });

            app.Run();

        }
    }
}



