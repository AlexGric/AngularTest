using AutoMapper;
using Business.ViewModels;
using DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Domain
{
    public class Account
    {
        IMapper mapper;
        AccountRepository repository;

        public Account(IConfiguration configuration)
        {
            this.repository = new AccountRepository(configuration);
            this.mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<DataAccess.Entity.Account, ViewModels.Account>();
            }).CreateMapper();
        }

        public IEnumerable<ViewModels.Account> Get()
        {
            var accounts = repository.Get();
            return accounts.Select(account => mapper.Map<DataAccess.Entity.Account, ViewModels.Account>(account));
        }
        public void SetRole(int id, Role role)
        {
            repository.SetRole(mapper.Map<Role, DataAccess.Entity.Role>( role),id);
           
        }
    }
}
