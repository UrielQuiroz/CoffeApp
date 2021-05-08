using CoffeApp.COMMON.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeApp.COMMON.Validadores
{
    public class VentaValidator:GenericValidator<Venta>
    {
        public VentaValidator()
        {
            RuleFor(x => x.EsVentaMovil).NotNull().NotEmpty();
            RuleFor(x => x.FechaHora).NotNull().NotEmpty();
            RuleFor(x => x.IdCliente).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.IdVendedor).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.Monto).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
