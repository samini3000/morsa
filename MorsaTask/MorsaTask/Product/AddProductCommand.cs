using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Product
{
    public class AddProductCommand : IRequest
    {
        public string Name;
        public string Description;
        public int Price;
        public int AccountRef;

        public AddProductCommand(Domain.Entities.Product product) 
        {
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            AccountRef = product.AccountRef;
        }
    }
}
