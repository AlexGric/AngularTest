using Microsoft.Extensions.Configuration;
using DataAccess.Entity;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class DogRepository
    {
        DogContext context;

        public DogRepository(IConfiguration configuration)
        {
            this.context = new DogContext(configuration);
        }

        public IEnumerable<Dog> Get()
        {
            var cats = context.Dogs.ToList();
            return cats;
        }
    }
}
