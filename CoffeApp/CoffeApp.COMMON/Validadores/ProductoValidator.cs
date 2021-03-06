using CoffeApp.COMMON.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeApp.COMMON.Validadores
{
    public class ProductoValidator:GenericValidator<Producto>
    {
        public ProductoValidator()
        {
            RuleFor(c => c.Costo).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(c => c.Descripcion).NotNull().NotEmpty();
            RuleFor(c => c.EsPreparado).NotNull().NotEmpty();
            RuleFor(c => c.EstaEnVenta).NotNull().NotEmpty();
            RuleFor(c => c.Foto).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(c => c.IdCategoria).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(c => c.Nombre).NotNull().NotEmpty().MaximumLength(100);
            RuleFor(c => c.Stock).NotNull().NotEmpty().GreaterThanOrEqualTo(0);
        }

    }
}
