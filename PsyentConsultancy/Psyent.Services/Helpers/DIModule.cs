using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Psyent.DataAccess;
using Psyent.DataAccess.EntityFramework;
using Psyent.DataModels;

namespace Psyent.Services.Helpers
{
    public static class DIModule
    {
        public static IServiceCollection RegisterModule(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<PsyentDbContext>(x => x.UseSqlServer(connectionString));

            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IRepository<Mentor>, MentorRepository>();

            return services;
        }
    }
}
