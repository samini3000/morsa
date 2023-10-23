using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account
{
    public sealed class AddAccountCommandHandler : IRequestHandler<AddAccountCommand>
    {
        private readonly IAccountRepository _accountRepository;
        
        public AddAccountCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task Handle(AddAccountCommand request, CancellationToken cancellationToken)
        {
            var account = new Domain.Entities.Account()
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                CanInsert = request.CanInsert,
            };
            await _accountRepository.AddAsync(account);
        }
    }
}
