using Sge.Service.Validators;
using SGE.Domain.Entities;
using SGE.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace Sge.Service.Interfaces
{
    public interface IProfessorDisciplinaService : IService<ProfessorDisciplina, ProfessorDisciplinaValidator>
    {
        IQueryable<ProfessorDisciplina> GetByIdDisciplina(int idDisciplina);
        IQueryable<ProfessorDisciplina> GetByIdProfessor(int idProfessor);
        ProfessorDisciplina GetByIds(int IdProfessor, int idDisciplina);
        void Delete(int IdProfessor, int idDisciplina);
    }
}
