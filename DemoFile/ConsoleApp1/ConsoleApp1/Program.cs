using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory=Directory.GetCurrentDirectory();
            Console.WriteLine(currentDirectory);

            //string newDir = $"{currentDirectory}/{DateTime.Now.Millisecond.ToString()}";
            //Directory.CreateDirectory(newDir);

            string filepath = $"{currentDirectory}/Martin.txt";
            if (!File.Exists(filepath))
            {
                File.Create(filepath);
            }

            File.AppendAllText(filepath, "hola mundo");
            var newfile = File.ReadAllLines(filepath);
            Console.WriteLine($"create file & Append");
            foreach (var a in newfile)
            {
                Console.WriteLine(a);
            }


            string[] subDir = Directory.GetDirectories(currentDirectory);
            Console.WriteLine($"----SubsDir-----");
            foreach (var a in subDir)
            {
                Console.WriteLine(a);
            }

            string[] file = Directory.GetFiles(currentDirectory,"*.exe");
            foreach (var v in file)
            {
                Console.WriteLine(v);
            }


            string root = Directory.GetDirectoryRoot(currentDirectory);
            Console.WriteLine($"----Root-----");
            foreach (var v in Directory.GetDirectories(root))
            {
                //Console.WriteLine(v);
            }
            Console.WriteLine(root);

            Console.ReadKey();
        }
    }
}
