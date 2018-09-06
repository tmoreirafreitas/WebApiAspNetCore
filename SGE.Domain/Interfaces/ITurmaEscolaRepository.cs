using SGE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Domain.Interfaces
{
    public interface ITurmaEscolaRepository : IRepository<TurmaEscola>
    {
        IEnumerable<TurmaEscola> GetByEscola(int idEscola);
    }
}
