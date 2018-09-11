using SGE.Domain.Entities;
using SGE.Domain.Interfaces;
using SGE.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Infra.Data.Repositories
{
    public class TrabalhaRepository : Repository<Trabalha>, ITrabalhaRepository
    {
        public TrabalhaRepository(SgeContext context) : base(context)
        {
        }
    }
}
