using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account
{
    public class AddAccountCommand: IRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool CanInsert { get; set; }
        public AddAccountCommand(Domain.Entities.Account account)
        {
            Name = account.Name;
            Email = account.Email;
            Password = account.Password;
            CanInsert = account.CanInsert;
        }
    }
}
