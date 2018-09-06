using SGE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Domain.Interfaces
{
    public interface IProfessorDisciplinaRepository : IRepository<ProfessorDisciplina>
    {
        IEnumerable<ProfessorDisciplina> GetByIdProfessor(int idProfessor);
        IEnumerable<ProfessorDisciplina> GetByIdDisciplina(int idDisciplina);
    }
}
