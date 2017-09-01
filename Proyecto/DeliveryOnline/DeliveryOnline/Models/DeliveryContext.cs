using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DeliveryOnline.Models
{
    public class DeliveryContext : DbContext
    {
        public DeliveryContext():base("DeliveryContext")
        {

        }
        public DbSet<Persona> Usuarios { get; set; }
        public DbSet<Tienda> Tiendas { get; set; }
        public DbSet<Repartidor> Repartidor { get; set; }
        public DbSet<Producto> Producto { get; set; }
        //public DbSet<TiendaUsuario> TiendaUsuario { get; set; }
    }
}