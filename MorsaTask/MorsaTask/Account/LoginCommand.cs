using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account
{
    public class LoginCommand : IRequest<string>
    {
        public string Email;
        public LoginCommand(string email)
        {
            Email = email;
        }
    }
}
