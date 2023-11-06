using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticaCelulares.Models.DTO
{
    public class RolesDTO
    {
        public int Id_Rol {  get; set; }
        public string Rol_Descripcion { get; set; }
        public int Activo { get; set; }
    }
}