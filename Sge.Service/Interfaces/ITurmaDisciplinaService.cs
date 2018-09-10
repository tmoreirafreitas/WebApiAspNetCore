using Sge.Service.Validators;
using SGE.Domain.Entities;
using SGE.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Sge.Service.Interfaces
{
    public interface ITurmaDisciplinaService: IService<TurmaDisciplina, TurmaDisciplinaValidator>
    {
        IEnumerable<TurmaDisciplina> GetBetweenDates(DateTime dateStart, DateTime dateEnd);
        IEnumerable<TurmaDisciplina> GetByDateStart(DateTime dateStart);
        IEnumerable<TurmaDisciplina> GetByDateEnd(DateTime dateEnd);
    }
}
