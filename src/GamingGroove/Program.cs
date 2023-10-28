using System.Globalization;
using GamingGroove.Controllers;
using GamingGroove.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http; // Adicionar para SameSiteMode
using Microsoft.AspNetCore.SignalR; // Adicionar para o SignalR

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
                    options.AccessDeniedPath = "/AcessoNegadoPage";
                    options.LoginPath = "/AcessoNegadoPage";
                });

            // 1. Adicionar suporte ao SignalR
            builder.Services.AddSignalR();

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

            // 2. Adicionar o mapeamento para o hub do chat
            app.MapHub<ChatHub>("/chatHub");

            app.MapControllerRoute(
                name: "home",
                pattern: "{controller=HomePage}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "perfil",
                pattern: "PerfilPage/{user}",
                defaults: new { controller = "PerfilPage", action = "Index" });

            app.MapControllerRoute(
                name: "comunidades",
                pattern: "ComunidadePage/{user}",
                defaults: new { controller = "ComunidadePage", action = "Index" });

            app.Run();

        }
    }
}
