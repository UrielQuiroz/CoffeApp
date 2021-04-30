using CoffeApp.COMMON.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeApp.COMMON.Validadores
{
    public class ElementoEnPaqueteValidator:GenericValidator<ElementoEnPaquete>
    {
        public ElementoEnPaqueteValidator()
        {
            RuleFor(c => c.IdPaquete).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(c => c.Cantidad).NotNull().GreaterThan(0);
            RuleFor(c => c.IdProducto).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(c => c.IdMenuComidaCorrida).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(c => c.Descripcion).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(c => c.Foto).NotNull().NotEmpty().MaximumLength(50);
        }
    }
}
