//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PracticaCelulares.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        public int Id_User { get; set; }
        public int Id_Rol { get; set; }
        public int Id_Tipo_Usuario { get; set; }
        public string UserName { get; set; }
        public string UserLogin { get; set; }
        public string Passwordkey { get; set; }
        public string Phone { get; set; }
        public int Activo { get; set; }
    
        public virtual Roles Roles { get; set; }
        public virtual Tipo_Usuario Tipo_Usuario { get; set; }
    }
}
