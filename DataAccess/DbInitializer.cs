using DataAccess.Entity;
using System.Linq;

namespace DataAccess
{
    public static class DbInitializer
    {
        public static void Initialize(DogContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Dogs.Any())
            {
                context.Dogs.AddRange(new Dog[] {
                new Dog() { Name = "Barbos", Age = 8 },
                new Dog() { Name = "Misha", Age = 6 },
                new Dog() { Name = "Sharik", Age = 9 },
                new Dog() { Name = "Bones", Age = 1 }
            });
            }

            if (!context.Accounts.Any())
            {
                context.Accounts.AddRange(new Account[] {
                    new Account() { Email = "user1@email.com", Password = "111111", Role = Role.User },
                    new Account() { Email = "user2@email.com", Password = "222222", Role = Role.User },
                    new Account() { Email = "admin@email.com", Password = "password", Role = Role.Admin }
                });
            }

            if (!context.Owners.Any())
            {
                context.Owners.AddRange(new Owner[] {
                    new Owner() { UserId = 1 , CatId = 1 },
                    new Owner() { UserId = 2 , CatId = 3 },
                    new Owner() { UserId = 2 , CatId = 4 }
                });
            }

            context.SaveChanges();
        }
    }
}
