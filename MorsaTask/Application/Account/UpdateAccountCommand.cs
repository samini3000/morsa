using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account
{
    public class UpdateAccountCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool CanInsert { get; set; }
        public UpdateAccountCommand(Domain.Entities.Account account)
        {
            Id = account.Id;
            Name = account.Name;
            Email = account.Email;
            Password = account.Password;
            CanInsert = account.CanInsert;
        }
    }
}
