using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockDemo
{
    class Program
    {
        static readonly object _object = new object();

        static void TestLock() {

            lock (_object)
            {
                Task.Delay(1000).Wait();
                Console.WriteLine(DateTime.Now + ":" + DateTime.Now.Millisecond);

            }

        }

        static void Main(string[] args)
        {
            for (int i=0; i < 10; i++)
            {
                Task.Run(()=> TestLock());
                Console.WriteLine($" For iteraccion: {i}");
            }
            Console.ReadKey();
        }
    }
}
