using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOnline.Models
{
    public interface IDeliveryContext
    {
        List<Persona> GetPersonas();
        List<Producto> GetProductos();
        List<Tienda> GetTiendas();

        Persona CrearPersona(Persona p);
        Producto CrearProducto(Producto p);
        Tienda CrearTienda(Tienda t);

        bool DeletePersona(Persona p);
        bool DeleteProducto(Producto p);
        bool DeleteTienda(Tienda t);

        Persona ModificarPersona(Persona p);
        Producto ModificarProducto(Producto p);
        Tienda ModificarTienda(Tienda t);

        Persona GetPersona(int id);
        Producto GetProducto(int id);
        Tienda GetTienda(int id);
    }
}
