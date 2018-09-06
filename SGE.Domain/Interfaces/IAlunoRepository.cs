using SGE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace SGE.Domain.Interfaces
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        Aluno GetByMatricula(string matricula);
        IEnumerable<Aluno> GetByName(Expression<Func<Aluno, bool>> predicate);
    }
}
