using Sge.Service.Validators;
using SGE.Domain.Entities;
using SGE.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sge.Service.Interfaces
{
    public interface ITurmaDisciplinaService: IService<TurmaDisciplina, TurmaDisciplinaValidator>
    {
        IQueryable<TurmaDisciplina> GetBetweenDates(DateTime dateStart, DateTime dateEnd);
        IQueryable<TurmaDisciplina> GetByDateStart(DateTime dateStart);
        IQueryable<TurmaDisciplina> GetByDateEnd(DateTime dateEnd);
        IQueryable<TurmaDisciplina> GetByIdTurma(int idTurma);
        TurmaDisciplina GetByIds(int idTurma, int idDisciplina);
        void Delete(int idTurma, int idDisciplina);

    }
}
