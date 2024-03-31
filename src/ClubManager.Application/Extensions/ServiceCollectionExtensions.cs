﻿using ClubManager.Application.User;
using Microsoft.Extensions.DependencyInjection;

namespace ClubManager.Application.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(ServiceCollectionExtensions).Assembly;

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        services.AddAutoMapper(assembly);

        services.AddScoped<IUserContext, UserContext>();

        services.AddHttpContextAccessor();
    }
}
