using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeApp.COMMON.Entidades
{
    public class Producto : BaseDTO
    {

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Foto { get; set; }
        public decimal Costo { get; set; }
        public string IdCategoria { get; set; }
        public bool EsPreparado { get; set; }
        public int Stock { get; set; }
        public bool EstaEnVenta { get; set; }

    }
}
