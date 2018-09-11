using SGE.Domain.Entities;
using SGE.Domain.Interfaces;
using SGE.Infra.Data.Context;

namespace SGE.Infra.Data.Repositories
{
    public class DisciplinaRepository : Repository<Disciplina>, IDisciplinaRepository
    {
        public DisciplinaRepository(SgeContext context) : base(context)
        {
        }
    }
}
