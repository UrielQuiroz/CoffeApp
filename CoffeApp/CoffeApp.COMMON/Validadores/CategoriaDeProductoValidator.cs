using CoffeApp.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace CoffeApp.COMMON.Validadores
{
    public class CategoriaDeProductoValidator:GenericValidator<CategoriaDeProducto>
    {
        public CategoriaDeProductoValidator()
        {
            RuleFor(c => c.Descripcion).NotEmpty().NotNull().WithMessage("La descripcion no puede estar vacia").MaximumLength(200);
            RuleFor(c => c.Nombre).NotEmpty().NotNull().MaximumLength(50).WithMessage("El nombre no puede estar vacio");
        }
    }
}
