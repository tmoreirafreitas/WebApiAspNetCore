using Sge.Service.Validators;
using SGE.Domain.Entities;
using SGE.Domain.Interfaces.Services;

namespace Sge.Service.Interfaces
{
    public interface IEscolaService : IService<Escola, EscolaValidator>
    {
        Escola GetByCnpj(string cnpj);
    }
}
