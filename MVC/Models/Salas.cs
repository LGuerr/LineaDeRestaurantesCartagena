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
    
    public partial class Salas
    {
        public Salas()
        {
            this.Reservas = new HashSet<Reservas>();
            this.Mesas = new HashSet<Mesas>();
        }
    
        public int id_sala { get; set; }
        public string nombre { get; set; }
        public Nullable<int> ambiente { get; set; }
        public string estado { get; set; }
        public int nit { get; set; }
        public int Foto_id_foto { get; set; }
    
        public virtual Foto Foto { get; set; }
        public virtual ICollection<Reservas> Reservas { get; set; }
        public virtual Restaurantes Restaurantes { get; set; }
        public virtual ICollection<Mesas> Mesas { get; set; }
        public virtual Ambiente Ambiente1 { get; set; }
    }
}