using Sge.Service.Validators;
using SGE.Domain.Entities;
using SGE.Domain.Interfaces.Services;

namespace Sge.Service.Interfaces
{
    public interface ITurmaService : IService<Turma, TurmaValidator>
    {
        Turma GetByCodigo(string codigo);
    }
}
