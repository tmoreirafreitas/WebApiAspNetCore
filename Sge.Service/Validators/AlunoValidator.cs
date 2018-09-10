using FluentValidation;
using SGE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sge.Service.Validators
{
    public class AlunoValidator : AbstractValidator<Aluno>
    {
        public AlunoValidator()
        {
            RuleFor(a => a).NotNull().OnAnyFailure(al=>
            {
                throw new ArgumentNullException("Can't found the object.");
            });

            RuleFor(a => a.Email)
                .NotEmpty().WithMessage("Is necessary to inform the E-mail.")
                .NotNull().WithMessage("Is necessary to inform the E-mail.");

            RuleFor(a=>a.Telefone)
                .NotEmpty().WithMessage("Is necessary to inform the Tel.")
                .NotNull().WithMessage("Is necessary to inform the Tel.");

            RuleFor(a => a.Nome)
                .NotEmpty().WithMessage("Is necessary to inform the Nome.")
                .NotNull().WithMessage("Is necessary to inform the Nome.");
        }
    }
}
