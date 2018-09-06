using SGE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Domain.Interfaces
{
    public interface IContatoRepository : IRepository<Contato>
    {
        Contato GetByTelefone(string telefone);
        Contato GetByEmail(string email);
    }
}
