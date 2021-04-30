using CoffeApp.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeApp.COMMON.Validadores
{
    public class PaqueteValidator:GenericValidator<Paquete>
    {
        public PaqueteValidator()
        {
            RuleFor(c => c.Foto).NotNull().NotEmpty().MaximumLength(50);
        }
    }
}
