using AutoMapper;
using DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace Business.Domain
{
    public class Owner
    {
        IMapper mapper;
        OwnerRepository repository;

        public Owner(IConfiguration configuration)
        {
            this.repository = new OwnerRepository(configuration);
            this.mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<DataAccess.Entity.Owner, ViewModels.Owner>();
            }).CreateMapper();
        }

        public IEnumerable<ViewModels.Owner> Get()
        {
            var owners = repository.Get();
            return owners.Select(owner => mapper.Map<DataAccess.Entity.Owner, ViewModels.Owner>(owner));
        }
        public ViewModels.Owner GetOwner(ViewModels.Owner owner)
        {
            var owners = repository.Get();
            var mappedOwner = mapper.Map<ViewModels.Owner, DataAccess.Entity.Owner>(owner);
            var res = owners.Where(x => x.Id == mappedOwner.Id).FirstOrDefault();
            return mapper.Map<DataAccess.Entity.Owner, ViewModels.Owner>(res);
        }
    }
}
