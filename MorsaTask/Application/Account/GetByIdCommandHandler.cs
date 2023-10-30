using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account
{
    public sealed class GetByIdCommandHandler : IRequestHandler<GetByIdCommand, Domain.Entities.Account?>
    {
        private readonly IAccountRepository _accountRepository;
        public GetByIdCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<Domain.Entities.Account?> Handle(GetByIdCommand request, CancellationToken cancellationToken)
        {
            return await _accountRepository.GetByIDAsync(request.Id);
        }
    }
}
