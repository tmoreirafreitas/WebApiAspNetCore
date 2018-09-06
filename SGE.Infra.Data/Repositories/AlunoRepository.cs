using SGE.Domain.Entities;
using SGE.Domain.Interfaces;
using SGE.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SGE.Infra.Data.Repositories
{
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(SgeContext context) : base(context)
        {
        }

        public Aluno GetByMatricula(string matricula)
        {            
            return GetByExpression(a => a.Matricula.Equals(matricula)).FirstOrDefault();
        }

        public IEnumerable<Aluno> GetByName(string nome)
        {
            return GetByExpression(a => a.Nome.Contains(nome));
        }
    }
}
