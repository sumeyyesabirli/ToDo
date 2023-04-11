using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using Todo.Persistence.Contexts;

namespace Blog.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EfDbContext>(x =>
            {
                x.UseNpgsql(configuration.GetConnectionString("EfDbContext"))
                    .LogTo(x => Debug.WriteLine(x));
                x.EnableSensitiveDataLogging();
            });
            services.AddScoped<DbContext, EfDbContext>();

        }
    }
}
