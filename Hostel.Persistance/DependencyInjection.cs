
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
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            string connection = configuration["ConnectionStrings:HostelConnectionN"];
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddDbContext<HostelContext>(_ => _.UseSqlServer(connection).EnableSensitiveDataLogging());

            return services;
        }
    }
}
