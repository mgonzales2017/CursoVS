using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefTVsValueT
{
    public class Test
    {
        public string A { get; set; }
    }

    public struct TestS
    {
        public string A { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Built in types
            Console.WriteLine("Tipos por valor:");
            int val1 = 10;
            int val2 = val1;
            val1++;
            val2 += 10;
            Console.WriteLine(val1);
            Console.WriteLine(val2);
            Console.ReadKey();

            Console.WriteLine("Tipos por referencia clases");
            Test s1 = new Test();
            s1.A = "Hola Mundo";
            Test s2 = s1;
            s2.A += "Waza";

            Console.WriteLine(s1.A);
            Console.WriteLine(s2.A);
            Console.ReadKey();

            Console.WriteLine("Tipos por Valor struct");
            TestS ss1 = new TestS();
            ss1.A = "Hola Mundo";
            TestS ss2 = ss1;
            ss2.A += "Waza";

            Console.WriteLine(ss1.A);
            Console.WriteLine(ss2.A);
            Console.ReadKey();
        }
    }
}
