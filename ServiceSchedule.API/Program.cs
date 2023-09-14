using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServiceSchedule.API.Middleware;
using ServiceSchedule.Infra.Data.Context;
using ServiceSchedule.Infra.IoC;
using System.Diagnostics.CodeAnalysis;

namespace ServiceSchedule.API;

[ExcludeFromCodeCoverage]
public static class Program
{
    static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Host.ConfigureAppConfiguration((config) =>
        {
            config.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        });

        #region Logging
        #endregion

        #region Memory Cache
        builder.Services.AddMemoryCache();
        #endregion

        builder.Services.AddDbContext<ServiceScheduleContext>();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",
                new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Service Schedule API",
                    Version = "v1",
                    Description = "API For Schedule Service",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Service Scheduler",
                    }
                });
        });


        builder.Services.AddControllers();

        builder.Services.AddLocalServices(builder.Configuration);

        builder.Services.AddOptions();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins", builder =>
            {
                builder.WithOrigins("http://localhost:4200");
                builder.AllowAnyMethod();
                builder.AllowAnyHeader()
                .WithExposedHeaders("Content-Disposition");
            });
        });

        var app = builder.Build();


        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseRouting();
        app.UseAuthorization();

        app.UseCors("AllowAllOrigins");

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Raízen - JDC - Letter V1");
        });

        app.UseMiddleware<UserMiddleware>();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.Run();
    }
}