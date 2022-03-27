using System;
using System.Collections.Generic;
using System.Text;

namespace BusStation
{
    public static class BusRequest
    {

        private static BusDepo depo = new BusDepo();
        public static void Request(string[] listCommands, string line)
        {
            switch (listCommands[0].ToUpper())
            {
                case "NEW_BUS":
                    depo.AddBus(line);
                    break;

                case "BUSES_FOR_STOP":
                    ShowBusesForStop(depo.GetBusesForStop(listCommands[1]));
                    break;

                case "STOPS_FOR_BUS":
                    ShowStops(depo.GetStopsForBus(listCommands[1]));
                    break;

                case "ALL_BUSES":
                    ShowBuses(depo.GetAllBuses());
                    break;
            }
        }
        private static void ShowStops(List<string> stops)
        {
            foreach (var stop in stops)
            {
                Console.WriteLine(stop);
            }
            Console.WriteLine();
        }

        private static void ShowBuses(List<string> buses)
        {
            foreach (var bus in buses)
            {
                Console.WriteLine(bus);
            }
        }
        private static void ShowBusesForStop(string buses)
        {
            Console.WriteLine(buses);
        }
    }
}
