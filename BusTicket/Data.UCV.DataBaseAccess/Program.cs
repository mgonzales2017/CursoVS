using Data.UCV.DataBaseAccess.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCV.Comun.Modelos;
using UCV.DataBaseAccess.Servicios.EntityContext;

namespace UCV.DataBaseAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            var servicioCompania = new ServicioCompania();

            var compania = new Compania()
            {

                Ruc = $"RUC Unico {new Random().Next(1, 10000).ToString()}",
                Calificacion = new Random().Next(1, 10)
            };

            var companias = new List<Compania>()
            {
                new Compania()
                {
                    Ruc = $"RUC Masivo Unico {new Random().Next(1, 10000).ToString()}",
                    Calificacion = new Random().Next(1, 10)
                },
                //null,
                //new Compania()
                //{
                //    Ruc = string.Empty,
                //    Calificacion = 1
                //},
            };

            servicioCompania.SaveCompania(compania);
            servicioCompania.SaveCompania(companias);

            foreach (var c in servicioCompania.GetCompania()) {
                Console.Write($"---Registro----");
                Console.Write($"{c.Id} - {c.Ruc}");
            }

            while (true) {
                if (Console.ReadLine() == "quit") {
                    break;
                }
            }


        }
    }
}
