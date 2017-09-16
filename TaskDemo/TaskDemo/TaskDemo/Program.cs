using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TaskDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncClass c = new AsyncClass();
            c.SumaAsync(1, 2).Wait();

            Task<int> asd = c.SumaAsync(1, 2);
            asd.Wait();

            await c.SumaAsync(1, 2);

        }

        public static void ParallelAsync() {

        }

        public async static void TaskAsync()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Antes de Ejecutar 15 segundos");
                Console.WriteLine("Luego de Ejecutar 15 Segundos");
            }
            );
        }

        public static void ParallelTest() {
            while (true)
            {

                //Ciclo que se ejcuta cada 5 segundos
                //Pueden aplicar System.Timers
                Task.Run(() => Console.WriteLine("x"));
                Task.Delay(5000).Wait();
            }


            Parallel.Invoke(() =>
            {
                Console.WriteLine("1. " + DateTime.Now.Millisecond);
                Task.Delay(new Random().Next(1000, 1000));
                Console.WriteLine("Termino metodo 1");
            },
            () =>
            {
                Console.WriteLine("2. " + DateTime.Now.Millisecond);
                Task.Delay(new Random().Next(1000, 1000));
                Console.WriteLine("Termino metodo 2");
            },
            () =>
            {
                Console.WriteLine("3. " + DateTime.Now.Millisecond);
                Task.Delay(new Random().Next(1000, 1000));
                Console.WriteLine("Termino metodo 3");
            }
            );

            Console.ReadKey();
        }

        public static void TaskTest()
        {
            System.Threading.CancellationToken x = new System.Threading.CancellationToken();

            Task task1 = new Task(() => {
                Console.WriteLine("Antes de Ejecutar 15 segundos");
                Task.Delay(15000).Wait();
                Console.WriteLine("Luego de Ejecutar 15 Segundos");
            }
            );
            task1.Start();
            var resultado = Task<string>.Run(() => {
                Console.WriteLine("Antes de Ejecutar 2");
                Task.Delay(10000).Wait();
                Console.WriteLine("Luego de Ejecutar 2");
                return "Hola Mundo";
            }).ContinueWith((q) => {
                Console.WriteLine("Antes de Ejecutar");
                Task.Delay(10000).Wait();
                Console.WriteLine("Luego de Ejecutar");
                return q + " Hola";
            });
            resultado.Wait();
            Console.WriteLine("Escribir por escribir");
            Console.WriteLine($"Resultado:{resultado.Result}");

            //task1.Start();
            Console.ReadKey();
        }
    }
}
