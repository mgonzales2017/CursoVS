using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Elija una opcion 1-3");
            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    BinarySerialization();
                    break;
                case '2':
                    XmlSerialization();
                    break;
                case '3':
                    JsonSerialization();
                    break;
            }
        }

        static void BinarySerialization()
        {
            Console.WriteLine("Binary Formatter");
            Console.WriteLine("Crear un objeto y Guardarlo serializado");

            string filepath = "miObjeto.txt";

            IFormatter formatter = new BinaryFormatter();
            Comida pizza = new Comida() { Componente = "Maza, Queso, Salsa de Tomate, Tocino, Aceitunas", Nombre = "Especial" };

            FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate);
            formatter.Serialize(fs, pizza);
            fs.Close();

            Console.ReadKey();

            fs = new FileStream(filepath, FileMode.Open);
            var c = (Comida)formatter.Deserialize(fs);
            Console.WriteLine(c.Componente);
            Console.WriteLine(c.Nombre);
            fs.Close();
            File.Delete(filepath);
            Console.ReadKey();
        }

        static void XmlSerialization()
        {
            Console.WriteLine("XML SOAP Formatter");
            Console.WriteLine("Crear un objeto y Guardarlo serializado");

            string filepath = "miObjeto.xml";

            // Necesita la referencia System.Runtime.Serialization.Formatter.Soap
            IFormatter formatter = new SoapFormatter();
            Comida pizza = new Comida() { Componente = "Maza, Queso, Salsa de Tomate, Tocino, Aceitunas", Nombre = "Especial" };

            FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate);
            formatter.Serialize(fs, pizza);
            fs.Close();

            Console.ReadKey();

            fs = new FileStream(filepath, FileMode.Open);
            var c = (Comida)formatter.Deserialize(fs);
            Console.WriteLine(c.Componente);
            Console.WriteLine(c.Nombre);
            fs.Close();
            File.Delete(filepath);
            Console.ReadKey();
        }

        static void JsonSerialization()
        {
            Console.WriteLine("Json Formatter");
            Console.WriteLine("Crear un objeto y Guardarlo serializado");

            string filepath = "miObjeto.json";

            Comida pizza = new Comida() { Componente = "Maza, Queso, Salsa de Tomate, Tocino, Aceitunas", Nombre = "Especial" };
            string json = JsonConvert.SerializeObject(pizza);
            FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate);
            using (StreamWriter sw = new StreamWriter(fs)) {
                sw.WriteLine(json);
            }
            fs.Close();

            //Console.ReadKey();

            fs = new FileStream(filepath, FileMode.Open,FileAccess.ReadWrite);
            string jsonStorage;
            using (StreamReader sr = new StreamReader(fs))
            {
                jsonStorage = sr.ReadToEnd();
            }

            var c = JsonConvert.DeserializeObject<Comida>(jsonStorage);
            // Serializar JSON a XML y Viceversa
            var transform = JsonConvert.DeserializeXmlNode(jsonStorage,"Comida");
            var result = JsonConvert.SerializeXmlNode(transform);
            // Serializar JSON a XML y Viceversa
            Console.WriteLine(c.Componente);
            Console.WriteLine(c.Nombre);
            fs.Close();
            File.Delete(filepath);
            Console.ReadKey();
        }
    }
    [Serializable]
    public class Comida : ISerializable
    {
        public string Componente { get; set; }
        public string Nombre { get; set; }

        public string minusculas { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("componente", Componente, typeof(string));
            info.AddValue("nombre", Nombre, typeof(string));
        }
        public Comida(SerializationInfo info, StreamingContext context)
        {
            Componente = (string)info.GetValue("componente", typeof(string));
            Nombre = (string)info.GetValue("nombre", typeof(string));
        }

        public Comida()
        {

        }

    }
}
