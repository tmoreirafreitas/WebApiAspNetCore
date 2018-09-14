using Sge.Service.Validators;
using SGE.Domain.Entities;
using SGE.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace Sge.Service.Interfaces
{
    public interface ITurmaEscolaService : IService<TurmaEscola, TurmaEscolaValidator>
    {
        IQueryable<TurmaEscola> GetByEscola(int idEscola);
    }
}
