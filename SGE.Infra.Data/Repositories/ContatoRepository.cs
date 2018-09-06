using SGE.Domain.Entities;
using SGE.Domain.Interfaces;
using SGE.Infra.Data.Context;
using System;
using System.Linq;

namespace SGE.Infra.Data.Repositories
{
    public class ContatoRepository : Repository<Contato>, IContatoRepository
    {
        public ContatoRepository(SgeContext context) : base(context)
        {
        }

        public Contato GetByEmail(string email)
        {
            return GetByExpression(c => c.Email.Equals(email)).FirstOrDefault();
        }

        public Contato GetByTelefone(string telefone)
        {
            return GetByExpression(c => c.Telefone.Equals(telefone)).FirstOrDefault();
        }
    }
}
