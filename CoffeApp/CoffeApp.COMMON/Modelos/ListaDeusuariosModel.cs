using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeApp.COMMON.Modelos
{
    public class ListaDeusuariosModel:AbstractModel
    {
        public string TipoDeUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }
        public decimal Credito { get; set; }
    }
}
