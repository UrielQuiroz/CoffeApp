using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeApp.COMMON.Entidades
{
    public class ElementoEnPaquete : BaseDTO
    {

        public string IdPaquete { get; set; }
        public string Foto { get; set; }
        public decimal Cantidad { get; set; }
        public string IdProducto { get; set; }
        public string IdMenuComidaCorrida { get; set; }
        public string Descripcion { get; set; }

    }
}
