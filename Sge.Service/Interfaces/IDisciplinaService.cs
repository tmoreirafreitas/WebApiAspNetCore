using Sge.Service.Validators;
using SGE.Domain.Entities;
using SGE.Domain.Interfaces.Services;

namespace Sge.Service.Interfaces
{
    public interface IDisciplinaService : IService<Disciplina, DisciplinaValidator>
    {
        Disciplina GetByCodigo(string codigo);
    }
}
