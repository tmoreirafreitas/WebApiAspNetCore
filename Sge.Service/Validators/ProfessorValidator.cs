using FluentValidation;
using SGE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sge.Service.Validators
{
    public class ProfessorValidator : AbstractValidator<Professor>
    {
        public ProfessorValidator()
        {

        }
    }
}
