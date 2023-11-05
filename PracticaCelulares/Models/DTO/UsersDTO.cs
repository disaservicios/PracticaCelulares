using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticaCelulares.Models.DTO
{
    public class UsersDTO
    {
        public int Id_User { get; set; }
        public string UserName { get; set; }
        public string UserLogin { get; set; }
        public string Passwordkey { get; set; }
        public string Tipo_Descripcion { get; set; }
        public string Rol_Descripcion { get; set; }
        public string Phone { get; set; }
    }
}