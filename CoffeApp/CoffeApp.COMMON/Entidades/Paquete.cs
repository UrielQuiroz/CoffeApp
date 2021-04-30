using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeApp.COMMON.Entidades
{
    public class Paquete : BaseDTO
    {

        public string Nombre { get; set; }
        public decimal Costo { get; set; }
        public bool EstaEnVenta { get; set; }
        public string Descripcion { get; set; }
    }
}
