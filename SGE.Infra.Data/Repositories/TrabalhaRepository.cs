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

        public IEnumerable<Trabalha> GetByDate(DateTime date)
        {
            return GetByExpression(t => t.Adimissao.Value.Day.Equals(date.Day)
            && t.Adimissao.Value.Month.Equals(date.Month)
            && t.Adimissao.Value.Year.Equals(date.Year));
        }
    }
}
