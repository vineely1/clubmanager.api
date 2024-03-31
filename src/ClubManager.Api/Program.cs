
using ClubManager.Application.Extensions;
using ClubManager.Domain.Entities;
using ClubManager.Infrastructure.Extensions;
using ClubManager.Api.Extensions;
using Serilog;

namespace ClubManager.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddInfrastructure(builder.Configuration);
        builder.Services.AddApplication();
        builder.Services.AddPresentation();
        builder.Services.Configure<RouteOptions>(options => { options.LowercaseUrls = true; });

        builder.Host.UseSerilog((context, configuration) =>
            configuration.ReadFrom.Configuration(context.Configuration)
        );

        var app = builder.Build();

        app.UseSerilogRequestLogging();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.MapGroup("api/identity")
            .WithTags("Identity")
            .MapIdentityApi<User>();

        app.UseCors(builder =>
            builder
                .WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader());

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
