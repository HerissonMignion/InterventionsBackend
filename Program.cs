using System;
using InterventionsBackend.DbContexts;
using InterventionsBackend.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading.RateLimiting;
using Microsoft.AspNetCore.RateLimiting;

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
        builder.Services.AddScoped<IProblemeRepository, ProblemeRepository>();
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

        app.UseRateLimiter(new Microsoft.AspNetCore.RateLimiting.RateLimiterOptions () {
            RejectionStatusCode = StatusCodes.Status429TooManyRequests
        }.AddConcurrencyLimiter("LimiterConcurrence", options => {
            options.PermitLimit = 2;
        }).AddFixedWindowLimiter("LimiterFenetre", options => {
            options.Window = TimeSpan.FromSeconds(5);
            options.PermitLimit = 10;
            options.QueueLimit = 5;
            options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        }));

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();


    }
}