using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PracticaCelulares.Models.DTOCrud
{
    public class cUsers
    {
        public int Id_User { get; set; }

        [Required]
        [Display (Name = "Nombre")]
        [StringLength(20,ErrorMessage ="El maximo de caracteres es 20")]
        public string UserName { get; set; }

        [Required]
        [Display (Name = "Usuario")]
        [StringLength(20, ErrorMessage = "El maximo de caracteres es 20")]
        public string UserLogin { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        [StringLength(20, ErrorMessage = "El maximo de caracteres es 20")]
        [DataType (DataType.Password)]
        public string Passwordkey { get; set; }

        [Display(Name = " Confirmar Contraseña")]
        [Compare("Passwordkey", ErrorMessage = "Las contraseñas no coinciden")]
        [StringLength(20, ErrorMessage = "El maximo de caracteres es 20")]
        [DataType(DataType.Password)]
        public string ConfirmPasswordkey { get; set; }

        [Required]
        [Display(Name = "Tipo de Usuario")]
        public string Tipo_Descripcion { get; set; }

        [Required]
        [Display(Name = "Rol")]
        public string Rol_Descripcion { get; set; }

        [Required]
        [Display (Name = "Telefono")]
        [StringLength(20, ErrorMessage = "El maximo de caracteres es 20")]
        public string Phone { get; set; }
    }

    public class EditcUsers
    {
        public int Id_User { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [StringLength(20, ErrorMessage = "El maximo de caracteres es 20")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        [StringLength(20, ErrorMessage = "El maximo de caracteres es 20")]
        public string UserLogin { get; set; }
        
        [Display(Name = "Contraseña")]
        [StringLength(20, ErrorMessage = "El maximo de caracteres es 20")]
        [DataType(DataType.Password)]
        public string Passwordkey { get; set; }

        [Display(Name = " Confirmar Contraseña")]
        [Compare("Passwordkey", ErrorMessage = "Las contraseñas no coinciden")]
        [StringLength(20, ErrorMessage = "El maximo de caracteres es 20")]
        [DataType(DataType.Password)]
        public string ConfirmPasswordkey { get; set; }

        [Required]
        [Display(Name = "Tipo de Usuario")]
        public string Tipo_Descripcion { get; set; }

        [Required]
        [Display(Name = "Rol")]
        public string Rol_Descripcion { get; set; }

        [Required]
        [Display(Name = "Telefono")]
        [StringLength(20, ErrorMessage = "El maximo de caracteres es 20")]
        public string Phone { get; set; }
    }
}