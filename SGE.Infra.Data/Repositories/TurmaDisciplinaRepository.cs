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

        public IEnumerable<TurmaDisciplina> GetBetweenDates(DateTime dateStart, DateTime dateEnd)
        {
            return GetByExpression(td => (td.DataInicio.Year >= (dateStart.Year)
            && td.DataInicio.Month >= (dateStart.Month)
            && td.DataInicio.Day >= (dateStart.Day))
            && (td.DataTermino.Year <= dateEnd.Year
            && td.DataTermino.Month <= dateEnd.Month
            && td.DataTermino.Day <= dateEnd.Day));
        }

        public IEnumerable<TurmaDisciplina> GetByDateEnd(DateTime dateEnd)
        {
            return GetByExpression(td => td.DataTermino.Year.Equals(dateEnd.Year)
            && td.DataTermino.Month.Equals(dateEnd.Month)
            && td.DataTermino.Day.Equals(dateEnd.Day));
        }

        public IEnumerable<TurmaDisciplina> GetByDateStart(DateTime dateStart)
        {
            return GetByExpression(td => td.DataInicio.Year.Equals(dateStart.Year)
            && td.DataInicio.Month.Equals(dateStart.Month)
            && td.DataInicio.Day.Equals(dateStart.Day));
        }
    }
}
