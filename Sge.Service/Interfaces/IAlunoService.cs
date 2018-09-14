using Sge.Service.Validators;
using SGE.Domain.Entities;
using SGE.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace Sge.Service.Interfaces
{
    public interface IAlunoService : IService<Aluno, AlunoValidator>
    {
        Aluno Get(string matricula);
        IQueryable<Aluno> GetByName(string nome);
    }
}
