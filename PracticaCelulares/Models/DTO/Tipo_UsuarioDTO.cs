using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticaCelulares.Models.DTO
{
    public class Tipo_UsuarioDTO
    {
        public int Id_Tipo_Usuario { get; set; }
        public string Tipo_Descripcion { get; set; }
        public int Activo { get; set; }

    }
}