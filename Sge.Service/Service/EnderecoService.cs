using Sge.Service.Interfaces;
using Sge.Service.Validators;
using SGE.Domain.Entities;
using SGE.Domain.Interfaces;
using System;
using System.Linq;

namespace Sge.Service.Service
{
    public class EnderecoService : Service<Endereco, EnderecoValidator>, IEnderecoService
    {
        private readonly IEnderecoRepository _repository;
        public EnderecoService(IEnderecoRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Endereco GetByCep(string cep)
        {
            if (string.IsNullOrEmpty(cep))
                throw new ArgumentException("O cep não pode ser vazio ou nulo.");

            return _repository.GetByExpression(e => e.Cep.Equals(cep)).FirstOrDefault();
        }
    }
}
