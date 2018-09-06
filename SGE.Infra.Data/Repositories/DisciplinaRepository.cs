using SGE.Domain.Entities;
using SGE.Domain.Interfaces;
using SGE.Infra.Data.Context;
using System.Linq;

namespace SGE.Infra.Data.Repositories
{
    public class DisciplinaRepository : Repository<Disciplina>, IDisciplinaRepository
    {
        public DisciplinaRepository(SgeContext context) : base(context)
        {
        }

        public Disciplina GetByCodigo(string codigo)
        {
            return GetByExpression(d => d.Codigo.Equals(codigo)).FirstOrDefault();
        }
    }
}
