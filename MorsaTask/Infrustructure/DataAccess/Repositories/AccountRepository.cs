using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DomainAccount = Domain.Entities.Account;
using DataAccount = Infrustructure.DataAccess.Entities.Account;
using Microsoft.EntityFrameworkCore;

namespace Infrustructure.DataAccess.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        MorsaDbContext _dbContext;

        //a bi directional mapper added
        private static MapperConfiguration _config = new MapperConfiguration(cfg => cfg.CreateMap<DomainAccount, DataAccount>().ReverseMap());
        private readonly Mapper _mapper = new Mapper(_config);

        public AccountRepository(MorsaDbContext morsaDbContext) 
        {
            _dbContext = morsaDbContext;
        }

        public async Task AddAsync(DomainAccount account)
        {
            await _dbContext.Accounts.AddAsync(_mapper.Map<DataAccount>(account));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<DomainAccount?> GetByEmailAsync(string email)
        {
            return await _dbContext.Accounts
                .Where(x=> x.Email == email)
                .Select(x => _mapper.Map<DomainAccount>(x))
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<DomainAccount?> GetByIDAsync(int id)
        {
            return await _dbContext.Accounts
                .Where(x => x.Id == id)
                .Select(x => _mapper.Map<DomainAccount>(x))
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public void UpdateAsync(DomainAccount account)
        {
            _dbContext.Accounts.Update(_mapper.Map<DataAccount>(account));
            _dbContext.SaveChanges();
        }
    }
}
