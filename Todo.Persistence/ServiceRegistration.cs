﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using Todo.Application.Repositories;
using Todo.Persistence.Contexts;
using Todo.Persistence.Repositories;

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
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITodoItemRepository, TodoItemRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

        }
    }
}