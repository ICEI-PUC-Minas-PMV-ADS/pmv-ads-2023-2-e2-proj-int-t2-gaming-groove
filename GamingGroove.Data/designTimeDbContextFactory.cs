using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using GamingGroove.Data;
using System;
using System.IO;
using MySql.Data.MySqlClient;


public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<GamingGrooveContext>
{
    public GamingGrooveContext CreateDbContext(string[] args)
    {
        // Define o caminho para o projeto principal onde o appsettings.json está localizado.
        var basePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "GamingGroove.Web"));

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<GamingGrooveContext>();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        builder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21)));

        return new GamingGrooveContext(builder.Options);
    }
}