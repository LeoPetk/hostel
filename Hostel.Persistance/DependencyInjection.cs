
using System;
using System.Text;
using Hostel.Application.Common.Repository;
using Hostel.Persistance.Context;
using Hostel.Persistance.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Hostel.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration, string machineName)
        {
            string connection = SetConnection(configuration, machineName);
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddDbContext<HostelContext>(_ => _.UseSqlServer(connection).EnableSensitiveDataLogging());

            return services;
        }

        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddIdentity<IdentityUser<Guid>, IdentityRole<Guid>>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 2;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredUniqueChars = 0;
            }).AddEntityFrameworkStores<HostelContext>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(config =>
            {
                config.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey =  new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Secret:HostelSecret"])),
                    ValidateIssuerSigningKey = true,
                    ValidAudience = configuration["Secret:HostelAudience"],
                    ValidIssuer = configuration["Secret:HostelIssuer"],
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true
                };
            });

            return services;
        }
        private static string SetConnection(IConfiguration configuration,string machineName)
        {
            return machineName.Equals("DESKTOP-BIMFVOP") ? configuration["ConnectionStrings:HostelConnectionN"] : configuration["ConnectionStrings:HostelConnectionV"];
        }
    }
}
