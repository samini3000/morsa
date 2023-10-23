using System;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction
{
    public interface IjwtProvider
    {
        public string Genrate(Domain.Entities.Account account);
    }
}
