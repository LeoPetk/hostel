
using Hostel.Application.Common.Repository;
using Hostel.Persistance.Context;
using Hostel.Persistance.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

        private static string SetConnection(IConfiguration configuration,string machineName)
        {
            return machineName.Equals("DESKTOP-BIMFVOP") ? configuration["ConnectionStrings:HostelConnectionN"] : configuration["ConnectionStrings:HostelConnectionV"];
        }
    }
}
