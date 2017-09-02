using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Binary Formatter");
            Console.WriteLine("Crear un objeto y guaradarlo");

            string filepath = "miObjeto.txt";
            IFormatter formater = new BinaryFormatter();
            Comida pizza = new Comida() { Componente = "Maza, queso, Salsa de Tomate, Tocino, champiñon, Cebolla" , Nombre="Especial" };

            FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate);
            formater.Serialize(fs, pizza);
            fs.Close();

            Console.ReadKey();


        }
    }
    [Serializable]
    public class Comida : ISerializable
    {
        public string Componente;
        public string Nombre;

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("componente", Componente, typeof(string));
            info.AddValue("nombre", Nombre, typeof(string));
        }

        public Comida (SerializationInfo info,StreamingContext context)
        {
            Componente = (string)info.GetValue("componente",typeof(string));
            Nombre = (string)info.GetValue("nombre", typeof(string));
        }

        public Comida()
        {
        }
    }

}
