using CoffeApp.COMMON.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeApp.COMMON.Validadores
{
    public class ElementoEnMenuValidator:GenericValidator<ElementoEnMenu>
    {
        public ElementoEnMenuValidator()
        {
            RuleFor(c => c.IdMenuComidaCorrida).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(c => c.IdProducto).NotNull().NotEmpty().MaximumLength(50);
        }
    }
}
