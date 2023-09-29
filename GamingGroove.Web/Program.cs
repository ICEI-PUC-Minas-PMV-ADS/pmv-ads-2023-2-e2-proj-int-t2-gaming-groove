using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GamingGroove.Data;
using MySql.Data.MySqlClient;


var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços necessários para o ASP.NET Core MVC (ou Razor Pages, se você estiver usando)
builder.Services.AddControllersWithViews(); // Use AddRazorPages() se você estiver usando Razor Pages

// Adiciona suporte ao DbContext
builder.Services.AddDbContext<GamingGrooveContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 21))));

var app = builder.Build();

// Configurações para desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Configura as rotas para o MVC (ou Razor Pages)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Inicia a aplicação
app.Run();

// Nota: Se você estiver usando Razor Pages, troque "MapControllerRoute" por "MapRazorPages" e ajuste o padrão de roteamento conforme necessário.