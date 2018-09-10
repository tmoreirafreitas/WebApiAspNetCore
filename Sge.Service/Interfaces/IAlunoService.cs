using Sge.Service.Validators;
using SGE.Domain.Entities;
using SGE.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Sge.Service.Interfaces
{
    public interface IAlunoService : IService<Aluno, AlunoValidator>
    {
        Aluno Get(string matricula);
        IEnumerable<Aluno> GetByName(string nome);
    }
}
