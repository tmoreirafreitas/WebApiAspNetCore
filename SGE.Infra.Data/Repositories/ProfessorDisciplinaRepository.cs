﻿using SGE.Domain.Entities;
using SGE.Domain.Interfaces;
using SGE.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Infra.Data.Repositories
{
    public class ProfessorDisciplinaRepository : Repository<ProfessorDisciplina>, IProfessorDisciplinaRepository
    {
        public ProfessorDisciplinaRepository(SgeContext context) : base(context)
        {
        }

        public IEnumerable<ProfessorDisciplina> GetByIdDisciplina(int idDisciplina)
        {
            return GetByExpression(pd => pd.IdDisciplina.Equals(idDisciplina));
        }

        public IEnumerable<ProfessorDisciplina> GetByIdProfessor(int idProfessor)
        {
            return GetByExpression(pd => pd.IdProfessor.Equals(idProfessor));
        }
    }
}
