using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeApp.COMMON.Entidades
{
    public class Venta : BaseDTO
    {

        public DateTime FechaHora { get; set; }
        public string IdCliente { get; set; }
        public string IdVendedor { get; set; }
        public bool EsVentaMovil { get; set; }
        public decimal Monto { get; set; }

    }
}
