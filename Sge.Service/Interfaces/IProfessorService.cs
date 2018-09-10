using Sge.Service.Validators;
using SGE.Domain.Entities;
using SGE.Domain.Interfaces.Services;

namespace Sge.Service.Interfaces
{
    public interface IProfessorService : IService<Professor, ProfessorValidator>
    {
        Professor GetByCpf(string cpf);
        Professor GetByMatricula(string matricula);
    }
}
