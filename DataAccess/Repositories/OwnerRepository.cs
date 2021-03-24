using DataAccess.Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
   public class OwnerRepository
    {
        DogContext context;

        public OwnerRepository(IConfiguration configuration)
        {
            this.context = new DogContext(configuration);
        }

        public IEnumerable<Owner> Get()
        {
            var owners = context.Owners.ToList();
            return owners;
        }
    }
}
