using Bogus;
using Bogus.DataSets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Core;
using Todo.Core.Entities;

namespace Todo.Persistence.Contexts
{
    internal class SeedData
    {
        private static List<User> GetUsers()
        {
            var result = new Faker<User>("tr")
                .RuleFor(i => i.Id, i => Guid.NewGuid())
                .RuleFor(i => i.CreatedDate, i => i.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
                .RuleFor(i => i.Name, i => i.Person.FirstName)
                .RuleFor(i => i.Email, i => i.Internet.Email())
                .RuleFor(i => i.Password, i => PasswordEncryptor.Encrpt(i.Internet.Password()))
                .Generate(10);
            return result;

        }

        public async Task SeedAsync(IConfiguration configuration)
        {
            var dbContextBuilder = new DbContextOptionsBuilder<EfDbContext>();
            dbContextBuilder.UseNpgsql(configuration["EfDbContext"]);

            var context = new EfDbContext(dbContextBuilder.Options);

            if (context.Users.Any())
            {
                await Task.CompletedTask;
                return;
            }

            var users = GetUsers();
            var userIds = users.Select(i => i.Id);
            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();
        }
    }
}
