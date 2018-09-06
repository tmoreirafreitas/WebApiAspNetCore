using SGE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Domain.Interfaces
{
    public interface ITurmaRepository : IRepository<Turma>
    {
        Turma GetByCodigo(string codigo);
    }
}
