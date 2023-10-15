using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prueba1.Models
{
    public class Usuarios
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public Rol IdRol { get; set; }
        public string ConfirmarClave { get; set; }


        
    }
}