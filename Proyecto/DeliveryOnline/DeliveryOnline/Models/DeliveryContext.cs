using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DeliveryOnline.Models
{
    public class DeliveryContext : DbContext,IDeliveryContext
    {
        public DeliveryContext():base("DeliveryContext")
        {

        }
        public DbSet<Persona> Usuarios { get; set; }
        public DbSet<Tienda> Tiendas { get; set; }
        public DbSet<Repartidor> Repartidor { get; set; }
        public DbSet<Producto> Productos { get; set; }

        public Persona CrearPersona(Persona p)
        {
            Usuarios.Add(p);
            SaveChanges();
            return p;
        }

        public Producto CrearProducto(Producto p)
        {
            Productos.Add(p);
            SaveChanges();
            return p;
        }

        public Tienda CrearTienda(Tienda t)
        {
            Tiendas.Add(t);
            SaveChanges();
            return t;
        }

        public bool DeletePersona(Persona p)
        {
            try
            {
                Usuarios.Remove(p);
                SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteProducto(Producto p)
        {
            try
            {
                Productos.Remove(p);
                SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteTienda(Tienda t)
        {
            try
            {
                Tiendas.Remove(t);
                SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Persona GetPersona(int id)
        {
            return Usuarios.FirstOrDefault(g => g.CodigoId == id);
        }

        public List<Persona> GetPersonas()
        {
            return Usuarios.ToList();
        }

        public Producto GetProducto(int id)
        {
            return Productos.FirstOrDefault(g => g.CodigoId == id);
        }

        public List<Producto> GetProductos()
        {
            return Productos.ToList();
        }

        public Tienda GetTienda(int id)
        {
            return Tiendas.FirstOrDefault(g => g.CodigoId == id);
        }

        public List<Tienda> GetTiendas()
        {
            return Tiendas.ToList();
        }

        public Persona ModificarPersona(Persona p)
        {
            var persona = Usuarios.FirstOrDefault(g => g.CodigoId == p.CodigoId);
            persona.Apellidos = p.Apellidos;
            persona.Direccion = p.Direccion;
            persona.Email = p.Email;
            persona.FonoCelular = p.FonoCelular;
            persona.Nombre = p.Nombre;
            persona.Password = p.Password;
            persona.User = p.User;
            SaveChanges();
            return persona;
        }

        public Producto ModificarProducto(Producto p)
        {
            var producto = Productos.FirstOrDefault(g => g.CodigoId == p.CodigoId);
            producto.descripcion = p.descripcion;
            producto.Imagen = p.Imagen;
            producto.TiendaId = p.TiendaId;
            SaveChanges();
            return producto;
        }

        public Tienda ModificarTienda(Tienda t)
        {
            var tienda = Tiendas.FirstOrDefault(g => g.CodigoId == t.CodigoId);
            tienda.Direccion = t.Direccion;
            tienda.Estado = t.Estado;
            tienda.FechaRegsitro = t.FechaRegsitro;
            tienda.NombreComercial = t.NombreComercial;
            tienda.RazonSocial = t.RazonSocial;
            tienda.Telefono = t.Telefono;
            SaveChanges();
            return tienda;
        }

    }
}