﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_68219_gourmetEntities : DbContext
    {
        public DB_68219_gourmetEntities()
            : base("name=DB_68219_gourmetEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Comidas> Comidas { get; set; }
        public virtual DbSet<Detalles> Detalles { get; set; }
        public virtual DbSet<Foto> Foto { get; set; }
        public virtual DbSet<Imegenes> Imegenes { get; set; }
        public virtual DbSet<Mesas> Mesas { get; set; }
        public virtual DbSet<Pedidos> Pedidos { get; set; }
        public virtual DbSet<Precios> Precios { get; set; }
        public virtual DbSet<Reservas> Reservas { get; set; }
        public virtual DbSet<Restaurantes> Restaurantes { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Salas> Salas { get; set; }
        public virtual DbSet<Servicios> Servicios { get; set; }
        public virtual DbSet<Zona> Zona { get; set; }
        public virtual DbSet<Cocina> Cocina { get; set; }
        public virtual DbSet<Ambiente> Ambiente { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
