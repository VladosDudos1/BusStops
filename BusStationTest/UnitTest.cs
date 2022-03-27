using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusStation;
using System.Collections.Generic;
using System;

namespace BusStationTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestBusForStations()
        {
            BusDepo depo = new BusDepo();
            depo.AddBus("NEW_BUS 5 3 SovietArea Marushkino Vnukovo");
            Assert.AreEqual(depo.GetBusesForStop("SovietArea"), "5");

            depo.AddBus("NEW_BUS 31 4 SovietArea Peredelkino Solntsevo Skolkovo");
            Assert.AreEqual("5 31", depo.GetBusesForStop("SovietArea"));
        }

        [TestMethod]
        public void TestAllBusesMethod()
        {
            BusDepo depo = new BusDepo();

            List<string> testList = new List<string>();

            testList.Add("No buses");
            CollectionAssert.AreEquivalent(depo.GetAllBuses(), testList);

            testList.Remove(testList[0]);

            testList = new List<string>
            {
                "Bus 33: Vnukovo Moskovsky Rumyantsevo Troparyovo",
                "Bus 5: Tolstopaltsevo Marushkino Vnukovo",
                "Bus 31: Tolstopaltsevo Marushkino Vnukovo Peredelkino Solntsevo Skolkovo",
                "Bus 34: Kokoshkino Marushkino Vnukovo Peredelkino Solntsevo Troparyovo"
            };

            depo.AddBus("NEW_BUS 5 3 Tolstopaltsevo Marushkino Vnukovo");
            depo.AddBus("NEW_BUS 31 6 Tolstopaltsevo Marushkino Vnukovo Peredelkino Solntsevo Skolkovo");
            depo.AddBus("NEW_BUS 34 6 Kokoshkino Marushkino Vnukovo Peredelkino Solntsevo Troparyovo");
            depo.AddBus("NEW_BUS 33 4 Vnukovo Moskovsky Rumyantsevo Troparyovo");

            CollectionAssert.AreEquivalent(testList, depo.GetAllBuses());
        }

        [TestMethod]
        public void TestStationСrossing()
        {
            BusDepo depo = new BusDepo();
            depo.AddBus("NEW_BUS 5 3 Tolstopaltsevo Marushkino Vnukovo");
            depo.AddBus("NEW_BUS 31 5 Tolstopaltsevo Marushkino Vnukovo Peredelkino Solntsevo");

            List<string> testList = new List<string>();
            testList.Add("Stop Tolstopaltsevo: 5");
            testList.Add("Stop Marushkino: 5");
            testList.Add("Stop Vnukovo: 5");
            testList.Add("Stop Peredelkino: no interchange");
            testList.Add("Stop Solntsevo: no interchange");

            CollectionAssert.AreEquivalent(testList, depo.GetStopsForBus("31"));
        }
    }
}