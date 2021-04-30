using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeApp.COMMON.Entidades
{
    public class ProductosEnVenta : BaseDTO
    {
        public string IdVenta { get; set; }
        public string IdProducto { get; set; }
        public string IdMenu { get; set; }
        public string IdPaquete { get; set; }
        public int Cantidad { get; set; }
        public decimal Costo { get; set; }
        public bool Preparando { get; set; }
        public bool Preparado { get; set; }
        public bool Entregado { get; set; }
    }
}
