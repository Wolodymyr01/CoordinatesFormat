using System;
using System.IO;
namespace CoordinatesFormat
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("If you would like to use a file, type 'f'. If you would like to use a console, type any other key");
            if (Console.ReadLine() == "f") // file
            {
                Console.WriteLine("Enter the path to the file.");
                string path = Console.ReadLine();
                while (!File.Exists(path))
                {
                    Console.WriteLine("Such file does not exist. Try again!");
                    path = Console.ReadLine();
                }
                FileStream fs = new FileStream(path, FileMode.Open);
                string src;
                using (StreamReader sr = new StreamReader(fs))
                {
                    src = sr.ReadToEnd();
                }
                fs.Close();
                var coords = src.Split("\n");
                foreach (var item in coords)
                {
                    string[] coord = item.Split(',');
                    if (coord.Length < 2)
                    {
                        Console.WriteLine("Wrong format");
                        continue;
                    }
                    Console.WriteLine($"X: {coord[0].Trim()} Y: {coord[1].Trim()}");
                }
            }
            else // console
            {
                Console.WriteLine("Enter coordinates or word 'stop' to exit.");
                while (true)
                {
                    var s = Console.ReadLine();
                    if (s == "stop") return;
                    var coors = s.Split(',');
                    if (coors.Length < 2)
                    {
                        Console.WriteLine("Wrong format. Try again or type 'stop' to exit.");
                        continue;
                    }
                    Console.WriteLine($"X: {coors[0].Trim()} Y: {coors[1].Trim()}");
                }
            }
        }
    }
}
