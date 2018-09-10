using Sge.Service.Validators;
using SGE.Domain.Entities;
using SGE.Domain.Interfaces.Services;

namespace Sge.Service.Interfaces
{
    public interface IEnderecoService : IService<Endereco, EnderecoValidator>
    {
        Endereco GetByCep(string cep);
    }
}
