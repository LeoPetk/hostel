using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using AutoMapper;
using FluentValidation;
using Hostel.Application.Common.Behaviors;
using Hostel.Application.Helpers.Authentification;
using Hostel.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Hostel.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped<IJwtManager, JwtManager>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehaviour<,>));
            return services;
        }
    }
}
