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
        private static List<Category> GetCategory()
        {
            var result = new Faker<Category>("tr")
                .RuleFor(i => i.Id, i => Guid.NewGuid())
                .RuleFor(i => i.CreatedDate, i => i.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
                .RuleFor(i => i.Description, i => i.Person.FirstName)
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

            var categories = GetCategory();
            var categoriesId = categories.Select(i => i.Id);
     
            await context.Categories.AddRangeAsync(categories);
          

            var guids = Enumerable.Range(0,15).Select(i=>Guid.NewGuid()).ToList();
            int counter = 0;

            var todo = new Faker<TodoItem>("tr")
                .RuleFor(i => i.Id, i => guids[counter++])
                .RuleFor(i => i.CreatedDate, i => i.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
                .RuleFor(i => i.Name, i => i.Lorem.Sentence(5,5))
                .RuleFor(i => i.CategoryId, i => i.PickRandom(categoriesId))        
                .Generate(10);

            
            var todoId = todo.Select(i => i.Id);
            await context.TodoItems.AddRangeAsync(todo);
            await context.SaveChangesAsync();
        }
    }
}
