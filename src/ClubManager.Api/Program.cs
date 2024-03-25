
using ClubManager.Domain.Entities;
using ClubManager.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

namespace ClubManager.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddInfrastructure(builder.Configuration);

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Type =  ReferenceType.SecurityScheme, Id = "bearerAuth"}
                    },
                    []
                }
            });
        });

        var app = builder.Build();

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
