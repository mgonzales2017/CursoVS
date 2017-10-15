using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DeliveryOnline.Models
{
    public class DeliveryContext : IdentityDbContext<Persona,TipoCliente,string,IdentityUserLogin,IdentityUserRole,IdentityUserClaim>, IDeliveryContext
    {
        public DeliveryContext() : base("DeliveryOnlineContext")
        {

        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Tienda> Tiendas { get; set; }
        
        public Persona CrearPersona(Persona p)
        {
            //Usuarios.Add(p);
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
                Users.Remove(p);
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
            var guid = id.ToString();
            return Users.FirstOrDefault(g => g.Id == guid);
        }

        public List<Persona> GetPersonas()
        {
            return Users.ToList();
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
            var persona = Users.FirstOrDefault(g => g.Id == p.Id);
            persona.Apellidos = p.Apellidos;
            persona.Direccion = p.Direccion;
            persona.Email = p.Email;
            persona.PhoneNumber = p.PhoneNumber;
            persona.Nombre = p.Nombre;
            persona.PasswordHash = p.PasswordHash;
            persona.UserName = p.UserName;
            SaveChanges();
            return persona;        }

        public Producto ModificarProducto(Producto p)
        {
            var producto = Productos.FirstOrDefault(g => g.CodigoId == p.CodigoId);
            producto.Descripcion = p.Descripcion;
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
            tienda.FechaRegsitro =t.FechaRegsitro;
            tienda.NombreComercial = t.NombreComercial;
            tienda.RazonSocial = t.RazonSocial;
            tienda.Telefono = t.Telefono;
            SaveChanges();
            return tienda;
        }

        public static DeliveryContext Create()
        {
            return new DeliveryContext();
        }
        
    }
}