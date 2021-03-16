using DataAccess.Entity;
using System.Linq;

namespace DataAccess
{
    public static class DbInitializer
    {
        public static void Initialize(DogContext context)
        {
            context.Database.EnsureCreated();

            if (context.Dogs.Any())
            {
                return;
            }

            context.Dogs.AddRange(new Dog[] {
                new Dog() { Name = "Barbos", Age = 8 },
                new Dog() { Name = "Misha", Age = 6 },
                new Dog() { Name = "Sharik", Age = 9 },
                new Dog() { Name = "Bones", Age = 1 }
            });

            context.SaveChanges();
        }
    }
}
