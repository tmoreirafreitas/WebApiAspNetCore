using SGE.Domain.Entities;
using SGE.Domain.Interfaces;
using SGE.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Infra.Data.Repositories
{
    public class ProfessorEscolaRepository : Repository<ProfessorEscola>, IProfessorEscolaRepository
    {
        public ProfessorEscolaRepository(SgeContext context) : base(context)
        {
        }
    }
}
