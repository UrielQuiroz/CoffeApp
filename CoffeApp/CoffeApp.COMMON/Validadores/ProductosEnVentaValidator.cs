using CoffeApp.COMMON.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeApp.COMMON.Validadores
{
    public class ProductosEnVentaValidator:GenericValidator<ProductosEnVenta>
    {
        public ProductosEnVentaValidator()
        {
            RuleFor(x => x.Cantidad).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.Costo).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.Entregado).NotNull().NotEmpty();
            RuleFor(x => x.IdMenu).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.IdProducto).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.IdVenta).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.Preparado).NotNull().NotEmpty();
            RuleFor(x => x.Preparando).NotNull().NotEmpty();
        }
    }
}
