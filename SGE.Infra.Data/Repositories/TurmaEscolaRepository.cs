using SGE.Domain.Entities;
using SGE.Domain.Interfaces;
using SGE.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Infra.Data.Repositories
{
    public class TurmaEscolaRepository : Repository<TurmaEscola>, ITurmaEscolaRepository
    {
        public TurmaEscolaRepository(SgeContext context) : base(context)
        {
        }

        public IEnumerable<TurmaEscola> GetByEscola(int idEscola)
        {
            return GetByExpression(te => te.IdEscola.Equals(idEscola));
        }
    }
}
