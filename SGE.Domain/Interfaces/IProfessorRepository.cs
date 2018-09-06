using SGE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Domain.Interfaces
{
    public interface IProfessorRepository : IRepository<Professor>
    {
        Professor GetByCpf(string cpf);
        Professor GetByMatricula(string matricula);
    }
}
