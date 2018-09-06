using SGE.Domain.Entities;
using SGE.Domain.Interfaces;
using SGE.Infra.Data.Context;
using System.Linq;

namespace SGE.Infra.Data.Repositories
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(SgeContext context) : base(context)
        {
        }

        public Endereco GetByCep(string cep)
        {
            return GetByExpression(e => e.Cep.Equals(cep)).FirstOrDefault();
        }
    }
}
