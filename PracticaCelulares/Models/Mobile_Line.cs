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
    
    public partial class Mobile_Line
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mobile_Line()
        {
            this.Call_Detail = new HashSet<Call_Detail>();
        }
    
        public int Id_Mobile_Line { get; set; }
        public int MobileLineId { get; set; }
        public int MobileLine { get; set; }
        public string CalledPartyDescription { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Call_Detail> Call_Detail { get; set; }
    }
}
