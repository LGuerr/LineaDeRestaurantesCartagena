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
    
    public partial class Servicios
    {
        public Servicios()
        {
            this.Pedidos = new HashSet<Pedidos>();
        }
    
        public int id_servicio { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int nit { get; set; }
    
        public virtual ICollection<Pedidos> Pedidos { get; set; }
        public virtual Restaurantes Restaurantes { get; set; }
    }
}
