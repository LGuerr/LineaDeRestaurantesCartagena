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
    
    public partial class User
    {
        public User()
        {
            this.Pedidos = new HashSet<Pedidos>();
            this.Reservas = new HashSet<Reservas>();
            this.Restaurantes = new HashSet<Restaurantes>();
        }
    
        public int cedula { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string telefono { get; set; }
        public int rol { get; set; }
        public string email { get; set; }
        public string Celular { get; set; }
        public System.DateTime fecha { get; set; }
        public string nickname { get; set; }
        public string password { get; set; }
        public string confirme { get; set; }
    
        public virtual ICollection<Pedidos> Pedidos { get; set; }
        public virtual ICollection<Reservas> Reservas { get; set; }
        public virtual ICollection<Restaurantes> Restaurantes { get; set; }
        public virtual Rol Rol1 { get; set; }
    }
}
