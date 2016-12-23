using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiClientServer
{
    class Program
    {
        static public int MijnPoort;
        static public Object locker = new object();

        static public Dictionary<int, Connection> Buren = new Dictionary<int, Connection>();

        static void Main(string[] args)
        {
            string[] input;
            if (args.Length < 1)
            {
                input = new string[1];
                input[0] = "1";
            }
            else
                input = args;
                
            Console.Title = input[0];
            MijnPoort = Int32.Parse(input[0]);
            new Server(MijnPoort);

            for (int i = 1; i < input.Length; i++)
            {
                lock (locker)
                {
                    if (!Buren.ContainsKey(Int32.Parse(input[i])))
                    {
                        Console.WriteLine("verbonden met " + input[i]);
                        Buren.Add(Int32.Parse(input[i]), new Connection(Int32.Parse(input[i])));
                        Console.WriteLine("done" + i);
                        
                    }
                    else Console.WriteLine("ALSO FUCK" + i);
                }
            }
            if (Console.ReadLine() == "exit")
            Console.WriteLine("exit");
        }
    }
}
