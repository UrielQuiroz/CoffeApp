using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeApp.COMMON.Entidades
{
    public class Usuario : BaseDTO
    {

        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Foto { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string IdTipoUsuario { get; set; }
        public decimal Credito { get; set; }
        public string Notas { get; set; }

    }
}
