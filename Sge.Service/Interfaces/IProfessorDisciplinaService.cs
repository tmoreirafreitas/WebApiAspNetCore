using Sge.Service.Validators;
using SGE.Domain.Entities;
using SGE.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Sge.Service.Interfaces
{
    public interface IProfessorDisciplinaService : IService<ProfessorDisciplina, ProfessorDisciplinaValidator>
    {
        IEnumerable<ProfessorDisciplina> GetByIdDisciplina(int idDisciplina);
        IEnumerable<ProfessorDisciplina> GetByIdProfessor(int idProfessor);
    }
}
