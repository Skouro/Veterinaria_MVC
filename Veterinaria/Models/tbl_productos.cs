//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Veterinaria.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_productos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_productos()
        {
            this.tbl_venta = new HashSet<tbl_venta>();
        }
    
        public string codigo_pd { get; set; }
        public string nombre_pd { get; set; }
        public string codigo_tp { get; set; }
        public double precio_pd { get; set; }
    
        public virtual tbl_tipoProducto tbl_tipoProducto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_venta> tbl_venta { get; set; }
    }
}
