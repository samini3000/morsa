using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account
{
    public sealed class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand>
    {
        private readonly IAccountRepository _accountRepository;
        public UpdateAccountCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                _accountRepository.UpdateAsync(new Domain.Entities.Account()
                {
                    Id = request.Id,
                    Name = request.Name,
                    Email = request.Email,
                    Password = request.Password,
                    CanInsert = request.CanInsert,
                });
            });
        }
    }
}
