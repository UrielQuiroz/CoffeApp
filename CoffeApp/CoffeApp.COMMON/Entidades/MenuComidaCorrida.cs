using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeApp.COMMON.Entidades
{
    public class MenuComidaCorrida : BaseDTO
    {
        public string Foto { get; set; }
        public string Nombre { get; set; }
        public decimal Costo { get; set; }
        public bool EstaEnVenta { get; set; }
        public string Descripcion { get; set; }

    }
}
