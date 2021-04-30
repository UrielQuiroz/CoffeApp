using CoffeApp.COMMON.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeApp.COMMON.Validadores
{
    public class GenericValidator<T> : AbstractValidator<T> where T : BaseDTO
    {

        public GenericValidator()
        {
            RuleFor(c => c.Id).NotNull().NotEmpty().MaximumLength(50).WithMessage("El valor de el ID no puede ser nulo o exceder de 50 caraceres");
        }

    }
}

