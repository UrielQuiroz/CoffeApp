using CoffeApp.COMMON.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeApp.COMMON.Validadores
{
    public class TipoUsuarioValidator:GenericValidator<TipoUsuario>
    {
        public TipoUsuarioValidator()
        {
            RuleFor(x => x.Nombre).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.Descripcion).NotNull().NotEmpty().MaximumLength(50);
        }
    }
}
