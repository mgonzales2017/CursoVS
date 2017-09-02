using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Herencia de genericos

            TestA<string> a = new TestA<string>();
            a.Meta1 = "Hola";
            a.Meta2 = "Mundo";
            a.AddRange(new TestA<string>()
            {
                "a","b","c","d"
            });
            List<string> b = new List<string>();
            var meta1 = "Hola";
            var meta2 = "Mundo";
            b.AddRange(new List<string>()
            {
                "a","b","c","d"
            });

            //Metodos de Extención

            Coninar cocina = new Coninar();
            cocina.Freir();
            cocina.Hornear();
            cocina.Quemar();
            cocina.Hervir();
            cocina.Servir();

        }
    }
    public class TestA<T> : List<T>
    {
        public string Meta1 { get; set; }
        public string Meta2 { get; set; }
    }

    public partial class Coninar
    {
        public List<string> Freir()
        {
            return new List<string>();
        }

        public List<string> Hornear()
        {
            return new List<string>();
        }

    }

    public static class CocinarExtention
    {
        public static List<string> Hervir(this Coninar c)
        {
            return new List<string>();
        }

        public static List<string> Servir(this Coninar c)
        {
            return new List<string>();
        }


    }
}
