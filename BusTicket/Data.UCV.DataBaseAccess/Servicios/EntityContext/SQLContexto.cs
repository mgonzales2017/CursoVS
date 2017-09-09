using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCV.Comun.Modelos;

namespace UCV.DataBaseAccess.Servicios.EntityContext
{
    public class SQLContexto : DbContext
    {

        public class SqlAnalisisContexto : DbContext
        {
            public DbSet<Ruta> Rutas { get; set; }
        }

        public SQLContexto() : base("SQLContexto")
        {
            
        }

        public DbSet<Compania> Companias { get; set; }

        public DbSet<Reserva> Reservas { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Ruta> Rutas { get; set; }

        public DbSet<Viajes> Viajes { get; set; }

    }
}
