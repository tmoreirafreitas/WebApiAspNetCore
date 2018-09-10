using FluentValidation;
using SGE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sge.Service.Validators
{
    public class DisciplinaValidator : AbstractValidator<Disciplina>
    {
        public DisciplinaValidator()
        {
            RuleFor(d => d).NotNull().OnAnyFailure(disc =>
            {
                throw new ArgumentNullException("Can't found the object.");
            });

            RuleFor(d => d.Codigo)
                .NotEmpty().WithMessage("Is necessary to inform the Codigo.")
                .NotNull().WithMessage("Is necessary to inform the Codigo.");

            RuleFor(d => d.Nome)
                .NotEmpty().WithMessage("Is necessary to inform the Nome.")
                .NotNull().WithMessage("Is necessary to inform the Nome.");

            RuleFor(d => d.CargaHoraria)
               .Equal(0).WithMessage("Is necessary to inform the CargaHoraria.");
        }
    }
}
