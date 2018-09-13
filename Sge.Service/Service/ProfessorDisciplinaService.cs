﻿using Sge.Service.Interfaces;
using Sge.Service.Validators;
using SGE.Domain.Entities;
using SGE.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Sge.Service.Service
{
    public class ProfessorDisciplinaService : Service<ProfessorDisciplina, ProfessorDisciplinaValidator>, IProfessorDisciplinaService
    {
        private readonly IProfessorDisciplinaRepository _repository;
        public ProfessorDisciplinaService(IProfessorDisciplinaRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public void Delete(int IdProfessor, int idDisciplina)
        {
            if (IdProfessor == 0)
                throw new ArgumentException("O IdProfessor não pode ser zero.");

            if (idDisciplina == 0)
                throw new ArgumentException("O idDisciplina não pode ser zero.");

            _repository.Delete(pd => pd.IdDisciplina.Equals(idDisciplina) && pd.IdProfessor.Equals(IdProfessor));
        }

        public IEnumerable<ProfessorDisciplina> GetByIdDisciplina(int idDisciplina)
        {
            if (idDisciplina == 0)
                throw new ArgumentException("O idDisciplina não pode ser zero.");

            return _repository.GetByExpression(pd => pd.IdDisciplina.Equals(idDisciplina));
        }

        public IEnumerable<ProfessorDisciplina> GetByIdProfessor(int idProfessor)
        {
            if (idProfessor == 0)
                throw new ArgumentException("O idProfessor não pode ser zero.");

            return _repository.GetByExpression(pd => pd.IdProfessor.Equals(idProfessor));
        }
    }
}
