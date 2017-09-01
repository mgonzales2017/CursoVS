using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoMVC2.Models
{
    public class Producto
    {
        public Producto()
        {

        }

        public Producto(string random)
        {
            if (random.Equals("random"))
            {
                ProductoId = Guid.NewGuid();
                Descripcion = $"Laptop HP {new Random().Next(10000)}";
                Precio = new Random().Next(100);
                Stock = new Random().Next(100);
                UnidadDeMedida = UnidadMedida.Pulgadas;
                ImagePath = "/Content/Producto.jpg";
            }
        }
        [Required]
        [StringLength(255)]
        public string Descripcion { get; set; }

        public byte[] Imagen { get; set; }
        public string ImagePath { get; set; }

        [Range(0, 1000000)]
        [Required]
        public decimal Precio { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$")]
        public int Stock { get; set; }

        [Required]
        [RegularExpression("^[{(]?[0-9A-F]{8}[-]?([0-9A-F]{4}[-]?){3}[0-9A-F]{12}[)}]?$")]
        public Guid ProductoId { get; set; }

        public UnidadMedida UnidadDeMedida { get; set; }
    }

    public enum UnidadMedida
    {
        Metros,
        Centímetros,
        Pulgadas,
        Kilogramos
    }
}