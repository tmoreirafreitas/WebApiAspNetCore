using Sge.Service.Interfaces;
using Sge.Service.Validators;
using SGE.Domain.Entities;
using SGE.Domain.Interfaces;
using System;
using System.Linq;

namespace Sge.Service.Service
{
    public class EscolaService : Service<Escola, EscolaValidator>, IEscolaService
    {
        private readonly IEscolaRepository _repository;
        public EscolaService(IEscolaRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Escola GetByCnpj(string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj))
                throw new ArgumentException("O cnpj não pode ser vazio ou nulo.");

            return _repository.GetByExpression(e => e.Cnpj.Equals(cnpj)).FirstOrDefault();
        }
    }
}
