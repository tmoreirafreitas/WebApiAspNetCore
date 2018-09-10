using Sge.Service.Interfaces;
using Sge.Service.Validators;
using SGE.Domain.Entities;
using SGE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sge.Service.Service
{
    public class TurmaEscolaService : Service<TurmaEscola, TurmaEscolaValidator>, ITurmaEscolaService
    {
        private readonly ITurmaEscolaRepository _repository;
        public TurmaEscolaService(ITurmaEscolaRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<TurmaEscola> GetByEscola(int idEscola)
        {
            if (idEscola == 0)
                throw new ArgumentException("The idEscola can't be zero.");

            return _repository.GetByExpression(te => te.IdEscola.Equals(idEscola));
        }
    }
}
