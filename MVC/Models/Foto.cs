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
    
    public partial class Foto
    {
        public Foto()
        {
            this.Categorias = new HashSet<Categorias>();
            this.Comidas = new HashSet<Comidas>();
            this.Mesas = new HashSet<Mesas>();
            this.Salas = new HashSet<Salas>();
        }
    
        public int id_foto { get; set; }
        public string img_foto { get; set; }
    
        public virtual ICollection<Categorias> Categorias { get; set; }
        public virtual ICollection<Comidas> Comidas { get; set; }
        public virtual ICollection<Mesas> Mesas { get; set; }
        public virtual ICollection<Salas> Salas { get; set; }
    }
}
