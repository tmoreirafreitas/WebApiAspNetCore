using SGE.Domain.Entities;
using SGE.Domain.Interfaces;
using SGE.Infra.Data.Context;
using System.Linq;

namespace SGE.Infra.Data.Repositories
{
    public class ProfessorRepository : Repository<Professor>, IProfessorRepository
    {
        public ProfessorRepository(SgeContext context) : base(context)
        {
        }

        public Professor GetByCpf(string cpf)
        {
            return GetByExpression(p => p.Cpf.Equals(cpf)).FirstOrDefault();
        }

        public Professor GetByMatricula(string matricula)
        {
            return GetByExpression(p => p.Matricula.Equals(matricula)).FirstOrDefault();
        }
    }
}
