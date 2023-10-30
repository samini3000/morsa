using Application.Abstraction;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account
{
    public sealed class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IjwtProvider _ijwtProvider;
        
        public LoginCommandHandler(IAccountRepository accountRepository, IjwtProvider ijwtProvider)
        {
            _accountRepository = accountRepository;
            _ijwtProvider = ijwtProvider;
        }
        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetByEmailAsync(request.Email);
            if (account == null)
            {
                return "invalid";
            }

            var token = _ijwtProvider.Genrate(account);

            return token;
        }
    }
}