using SGE.Domain.Entities;
using SGE.Domain.Interfaces;
using SGE.Infra.Data.Context;
using System.Linq;

namespace SGE.Infra.Data.Repositories
{
    public class EscolaRepository : Repository<Escola>, IEscolaRepository
    {
        public EscolaRepository(SgeContext context) : base(context)
        {
        }
    }
}
