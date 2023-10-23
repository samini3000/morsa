using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IProductRepository
    {
        public Task AddProductAsync(Product product);
        public IEnumerable<Product> GetAllProducts();
    }
}
