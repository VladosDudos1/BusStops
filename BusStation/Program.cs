using System;

namespace BusStation
{
    class Program
    {
        public static void Main(string[] args)
        {

            int querryCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < querryCount; i++)
            {
                string line = Console.ReadLine();
                string[] listCommands = line.Split();

                BusRequest.Request(listCommands, line);
            }
        }
    }
}