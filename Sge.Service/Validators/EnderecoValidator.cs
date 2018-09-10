using FluentValidation;
using SGE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sge.Service.Validators
{
    public class EnderecoValidator : AbstractValidator<Endereco>
    {
        public EnderecoValidator()
        {
            RuleFor(e => e).NotNull().OnAnyFailure(end =>
            {
                throw new ArgumentNullException("Can't found the object.");
            });

            RuleFor(e => e.Bairro)
                .NotEmpty().WithMessage("Is necessary to inform the Bairro.")
                .NotNull().WithMessage("Is necessary to inform the Bairro.");

            RuleFor(e => e.Cep)
                .NotEmpty().WithMessage("Is necessary to inform the Cep.")
                .NotNull().WithMessage("Is necessary to inform the Cep.");

            RuleFor(e => e.Cidade)
                .NotEmpty().WithMessage("Is necessary to inform the Cidade.")
                .NotNull().WithMessage("Is necessary to inform the Cidade.");

            RuleFor(e => e.Logradouro)
                .NotEmpty().WithMessage("Is necessary to inform the Logradouro.")
                .NotNull().WithMessage("Is necessary to inform the Logradouro.");

            RuleFor(e => e.UF)
                .NotEmpty().WithMessage("Is necessary to inform the UF.")
                .NotNull().WithMessage("Is necessary to inform the UF.");
        }
    }
}
