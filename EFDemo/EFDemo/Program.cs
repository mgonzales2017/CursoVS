using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo
{
    class Program
    {
        public void PerformanceTest()
        {

            CodeFirst.MenuContext contexto = new CodeFirst.MenuContext();
            // Toma como 15 minutos en crearse.
            for (int i = 0; i < 5000; i++)
            {
                CodeFirst.Menu m = new CodeFirst.Menu() { Id = Guid.NewGuid() };
                for (int j = 0; j < 5; j++)
                {
                    CodeFirst.Cafe c = new CodeFirst.Cafe()
                    {
                        Grano = "g",
                        Menu = m,
                        MenuId = m.Id,
                        Id = Guid.NewGuid(),
                    };
                    contexto.Cafes.Add(c);
                }
                contexto.Menus.Add(m);
            }
            contexto.SaveChanges();
            var late = contexto.Cafes.ToList().Where(l => l.Menu.Id.ToString().Contains("2") && l.MenuId != null);
            Console.WriteLine(late.Count());
            var fast = contexto.Cafes.Where(l => l.Menu.Id.ToString().Contains("2") && l.MenuId != null).ToList();
            Console.WriteLine(fast.Count());
        }
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

            // LINQ Examples

            // LINQ Explicito
            var q = from cafe in contexto.Cafes.ToList() select cafe;
            var qq = from cafe in q where cafe.Grano != null select cafe;

            // Filtra pero no llama a la base de datos solo genera querys
            var query = from cafe in contexto.Cafes
                        where cafe.Grano != null
                        select cafe;
            var le = contexto.Cafes.Where(cafe => cafe.Grano != null);

            // Llama primero DB luego filtra
            var query2 = from cafe in contexto.Cafes.ToList()
                         where cafe.Grano != null
                         select cafe;
            var le2 = contexto.Cafes.ToList().Where(cafe => cafe.Grano != null);

            // Filtra y luego llama a la base de datos
            var query3 = (from cafe in contexto.Cafes
                          where cafe.Grano != null
                          select cafe).ToList();
            var le3 = contexto.Cafes.Where(cafe => cafe.Grano != null).ToList();

            // Multiples linq
            var queryextendido = from ilegible in (from m in (from menu in contexto.Menus
                                                              where menu.Id != null &&
                                                              menu.Id.ToString().Contains("3")
                                                              select menu)
                                                   where m.Id.ToString().Contains("2")
                                                   select m)
                                 where ilegible.Id.ToString().Contains("1")
                                 select ilegible;
            var leextendido = contexto.Menus.
                Where(menu => menu.Id != null && menu.Id.ToString().Contains("3")).
                Where(m => m.Id.ToString().Contains("2")).
                Where(ilegible => ilegible.Id.ToString().Contains("1"));

            var select = from menu in contexto.Menus
                         select new CodeFirst.Cafe() { Id = Guid.NewGuid(), Menu = menu, MenuId = menu.Id };

            var ls = contexto.Menus.Select(menu => new CodeFirst.Cafe() { Id = Guid.NewGuid(), Menu = menu, MenuId = menu.Id });

            //for (int i = 0; i < 10000; i++)
            //{
            //    contexto.Menus.Add(new CodeFirst.Menu() { Id = Guid.NewGuid() });
            //}
            //contexto.SaveChanges();
            // LINQ Lineal o de Extension.


        }
    }
}
