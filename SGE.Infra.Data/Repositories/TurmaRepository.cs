using SGE.Domain.Entities;
using SGE.Domain.Interfaces;
using SGE.Infra.Data.Context;
using System.Linq;

namespace SGE.Infra.Data.Repositories
{
    public class TurmaRepository : Repository<Turma>, ITurmaRepository
    {
        public TurmaRepository(SgeContext context) : base(context)
        {
        }
    }
}
