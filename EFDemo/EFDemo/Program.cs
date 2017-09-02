using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            CodeFirst.MenuContext contexto = new CodeFirst.MenuContext();

            Guid g = Guid.NewGuid();
            CodeFirst.Te te = new CodeFirst.Te()
            {
                Id = Guid.NewGuid(),
                Aroma = "Manzanilla" + new Random().Next(1, 100).ToString(),
                Textura = "Suave" + new Random().Next(1, 100).ToString(),
                Infusion = "Manzanilla" + new Random().Next(1, 100).ToString(),
                Menu = new CodeFirst.Menu() { Id = g },
                MenuId = g,
            };
            contexto.Tes.Add(te);

            var objAModificar = contexto.Cafes.FirstOrDefault();
            objAModificar.Grano = "Modicar" + new Random().Next(1, 100).ToString();
            objAModificar.MenuId = g;

            var teABorrar = contexto.Tes.FirstOrDefault();
            contexto.Tes.Remove(teABorrar);

            // Los estados varian para sus funciones
            // Added crea uno nuevo e intenta que sea con un nuevo ID
            // Deleted Remueve un objeto que este dentro de la persistencia
            // Detached Remueve un objeto para que no sea agregado, si esta guardado no hace nada
            // Modified sobre escribe los datos
            // Unchanged no hace nada, es el estado por defecto
            contexto.Entry(teABorrar).State = System.Data.Entity.EntityState.Unchanged;

            contexto.SaveChanges();


            foreach (var c in contexto.Tes)
            {
                Console.WriteLine($"Id:{c.Id} Infusion:{c.Infusion} Textura:{c.Textura} Amora:{c.Aroma}");
            }
            Console.ReadKey();


        }
    }
}
