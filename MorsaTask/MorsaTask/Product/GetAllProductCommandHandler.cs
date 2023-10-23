using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Product
{
    public sealed class GetAllProductCommandHandler : IRequestHandler<GetAllProductCommand, IEnumerable<Domain.Entities.Product>>
    {
        private readonly IProductRepository _productRepository;
        
        public GetAllProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<Domain.Entities.Product?>> Handle(GetAllProductCommand request, CancellationToken cancellationToken)
        {
            return  Task.Run(() =>
            {
                return _productRepository.GetAllProducts();
            }).Result;
        }
    }
}
