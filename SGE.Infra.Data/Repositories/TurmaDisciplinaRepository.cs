using SGE.Domain.Entities;
using SGE.Domain.Interfaces;
using SGE.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Infra.Data.Repositories
{
    public class TurmaDisciplinaRepository : Repository<TurmaDisciplina>, ITurmaDisciplinaRepository
    {
        public TurmaDisciplinaRepository(SgeContext context) : base(context)
        {
        }
    }
}
