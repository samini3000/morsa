using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainProduct = Domain.Entities.Product;
using DataProduct = Infrustructure.DataAccess.Entities.Product;
using Infrustructure.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrustructure.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        MorsaDbContext _dbContext;

        //a bi directional mapper added
        private static MapperConfiguration _config = new MapperConfiguration(cfg => cfg.CreateMap<DomainProduct, DataProduct>().ReverseMap());
        private readonly Mapper _mapper = new Mapper(_config);

        public ProductRepository(MorsaDbContext morsaDbContext)
        {
            _dbContext = morsaDbContext;
        }
        public async Task AddProductAsync(DomainProduct product)
        {
            await _dbContext.Products.AddAsync(_mapper.Map<DataProduct>(product));
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<DomainProduct> GetAllProducts()
        {
            return _dbContext.Products
                .Select(x => _mapper.Map<DomainProduct>(x))
                .ToList();
        }
    }
}
