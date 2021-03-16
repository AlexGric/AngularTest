using AutoMapper;
using Microsoft.Extensions.Configuration;
using DataAccess.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Business.Domain
{
    public class Dog
    {
        DogRepository repository;
        IMapper mapper;

        public Dog(IConfiguration configuration)
        {
            this.repository = new DogRepository(configuration);
            this.mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<DataAccess.Entity.Dog, ViewModels.Dog>();
            }).CreateMapper();
        }

        public IEnumerable<ViewModels.Dog> Get()
        {
            var dogs = repository.Get();
            return dogs.Select(dog => mapper.Map<DataAccess.Entity.Dog, ViewModels.Dog>(dog));
        }
    }
}