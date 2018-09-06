using SGE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Domain.Interfaces
{
    public interface ITurmaDisciplinaRepository : IRepository<TurmaDisciplina>
    {
        IEnumerable<TurmaDisciplina> GetBetweenDates(DateTime dateStart, DateTime dateEnd);
        IEnumerable<TurmaDisciplina> GetByDateStart(DateTime dateStart);
        IEnumerable<TurmaDisciplina> GetByDateEnd(DateTime dateEnd);
    }
}
