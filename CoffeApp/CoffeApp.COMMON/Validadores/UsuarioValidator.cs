using CoffeApp.COMMON.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeApp.COMMON.Validadores
{
    public class UsuarioValidator:GenericValidator<Usuario>
    {
        public UsuarioValidator()
        {

            RuleFor(x => x.Nombre).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.Email).NotNull().NotEmpty().MaximumLength(50).EmailAddress();
            RuleFor(x => x.Credito).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Foto).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.IdTipoUsuario).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.Nombre).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.NombreUsuario).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.Notas).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.Password).NotNull().NotEmpty().MaximumLength(50).EmailAddress();
            RuleFor(x => x.Telefono).NotNull().NotEmpty().MaximumLength(50).EmailAddress();

        }
    }
}
