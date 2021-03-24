using DataAccess.Entity;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class AccountRepository
    {
        DogContext context;

        public AccountRepository(IConfiguration configuration)
        {
            this.context = new DogContext(configuration);
        }

        public IEnumerable<Account> Get()
        {
            var accounts = context.Accounts.ToList();
            return accounts;
        }

        public void SetRole(Role role, int id)
        {
            var account = context.Accounts.Where(x=>x.Id == id).FirstOrDefault();
            account.Role = role;
            context.SaveChanges();
            
        }
    }
}
