using CoffeApp.COMMON.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeApp.COMMON.Validadores
{
    public class PaqueteValidator:GenericValidator<Paquete>
    {
        public PaqueteValidator()
        {
            RuleFor(c => c.Costo).NotNull().NotEmpty().GreaterThan(50);
            RuleFor(c => c.Descripcion).NotNull().NotEmpty();
            RuleFor(c => c.EstaEnVenta).NotNull().NotEmpty();
            RuleFor(c => c.Nombre).NotNull().NotEmpty().MaximumLength(100);
        }
    }
}
