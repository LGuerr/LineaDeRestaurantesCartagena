//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Precios
    {
        public Precios()
        {
            this.Comidas = new HashSet<Comidas>();
        }
    
        public int id_precio { get; set; }
        public decimal precio { get; set; }
        public decimal iva { get; set; }
    
        public virtual ICollection<Comidas> Comidas { get; set; }
    }
}