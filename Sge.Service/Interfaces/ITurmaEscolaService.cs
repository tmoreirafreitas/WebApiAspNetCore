using Sge.Service.Validators;
using SGE.Domain.Entities;
using SGE.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Sge.Service.Interfaces
{
    public interface ITurmaEscolaService : IService<TurmaEscola, TurmaEscolaValidator>
    {
        IEnumerable<TurmaEscola> GetByEscola(int idEscola);
    }
}
