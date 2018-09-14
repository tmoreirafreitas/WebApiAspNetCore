using Sge.Service.Validators;
using SGE.Domain.Entities;
using SGE.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sge.Service.Interfaces
{
    public interface IProfessorEscolaService : IService<ProfessorEscola, ProfessorEscolaValidator>
    {
        IQueryable<ProfessorEscola> GetByDate(DateTime date);
        ProfessorEscola GetByIds(int IdProfessor, int IdEscola);
        void Delete(int IdProfessor, int IdEscola);
    }
}
