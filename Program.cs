using System;
using InterventionsBackend.DbContexts;
using InterventionsBackend.Services;
using Microsoft.EntityFrameworkCore;

public partial class Program {
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        

        // Add services to the container.
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddApiVersioning(setupAction => {
            setupAction.AssumeDefaultVersionWhenUnspecified = true;
            setupAction.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
            setupAction.ReportApiVersions = true;
        });

        builder.Services.AddDbContext<InterventionsDbContext>(
            cfg => {
                string connectionString = builder.Configuration.GetConnectionString("InterventionsConnection");
                cfg.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        );
        // if (builder.Environment.IsProduction()) {
        // }
        builder.Services.AddScoped<ITypesProblemeRepository, TypesProblemeRepository>();
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();


    }
}