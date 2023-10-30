using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account
{
    public class GetByIdCommand : IRequest<Domain.Entities.Account?>
    {
        public int Id { get; set; }
        public GetByIdCommand(int id) 
        { 
            Id = id;
        }
    }
}
