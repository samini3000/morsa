using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IAccountRepository
    {
        public Task AddAsync(Account account);
        public Task<Account?> GetByEmailAsync(string email);
        public Task<Account?> GetByIDAsync(int id);
        public void UpdateAsync(Account account);
    }
}
