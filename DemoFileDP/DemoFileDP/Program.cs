using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFileDP
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine(currentDirectory);

            //string newDirectory = $"{currentDirectory}/{DateTime.Now.Millisecond.ToString()}";
            //Directory.CreateDirectory(newDirectory);
            string filepath = $"{currentDirectory}/Moises.txt";
            FileStream stream = null;
            if (!File.Exists(filepath))
            {
                stream = File.Create(filepath,1024,FileOptions.RandomAccess);
            }
            // Streams
            try
            {
                if (stream == null) stream = File.Open(filepath, FileMode.Append,FileAccess.Write);
                using (StreamWriter sw = new StreamWriter(stream))
                {
                    Console.WriteLine($"---------Stream Writer-----------");
                    sw.WriteLine("Hola Mundo Texto");
                    sw.WriteLine("Hola Clase");
                    foreach (var v in Directory.GetDirectories(Directory.GetDirectoryRoot(currentDirectory)))
                    {
                        sw.WriteLine(v);
                    }
                }
            } 
            catch
            {
                throw;
            }
            finally
            {
                stream.Close();
            }

            using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader r = new StreamReader(fs))
                {
                    Console.WriteLine($"------Stream Reader ---------");
                    Console.WriteLine(r.ReadToEnd());
                }
            }

            // Static methods
            File.AppendAllText(filepath, "hola mundo\n\r");
            var newfile = File.ReadAllLines(filepath);
            Console.WriteLine($"----Create File & Append");
            foreach(var v in newfile)
            {
                Console.WriteLine(v);
            }

            string[] subDir = Directory.GetDirectories(currentDirectory);
            Console.WriteLine($"------SubDirs-----");
            foreach(var v in subDir)
            {
                Console.WriteLine(v);
            }

            string[] file = Directory.GetFiles(currentDirectory);
            Console.WriteLine($"------Files-----");
            foreach(var v in file)
            {
                Console.WriteLine(v);
            }



            string root = Directory.GetDirectoryRoot(currentDirectory);
            Console.WriteLine($"------Root------");
            Console.WriteLine(root);
            foreach (var v in Directory.GetDirectories(root))
            {
                //Console.WriteLine(v);
            }
            Console.ReadKey();
            
        }
    }
}
