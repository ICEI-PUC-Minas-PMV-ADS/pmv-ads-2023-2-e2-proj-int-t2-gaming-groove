using System;
using System.Globalization;
using GamingGroove.Controllers;
using GamingGroove.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http; // Adicionar para SameSiteMode
using Microsoft.AspNetCore.SignalR; // Adicionar para o SignalR
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

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

            #if DEBUG
            builder.Services.AddDbContext<GamingGrooveDbContext>(
                options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnectionLocal"),
                new MySqlServerVersion(new Version(8, 0, 34))) 
            );
            #else
            builder.Services.AddDbContext<GamingGrooveDbContext>(
                options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                new MySqlServerVersion(new Version(8, 0, 34))) 
            );
            #endif

            builder.Services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => {
                    options.AccessDeniedPath = "/AcessoNegadoPage";
                    options.LoginPath = "/AcessoNegadoPage";
            });

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession();    

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

            // 2. Adicionar o mapeamento para o hub do chat
            app.MapHub<ChatHub>("/chatHub");

            // 3. Adicione as configurações de sessão antes de UseAuthentication e UseAuthorization
            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "home",
                pattern: "{controller=HomePage}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "perfil",
                pattern: "PerfilPage/{user}",
                defaults: new { controller = "PerfilPage", action = "Index" });
                
            app.MapControllerRoute(
                name: "comunidades",
                pattern: "ComunidadePage/{community}",
                defaults: new { controller = "ComunidadePage", action = "Index" });

            app.Run();
        }
    }
}
