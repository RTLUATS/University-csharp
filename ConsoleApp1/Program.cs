using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    delegate void Deleg(List<Airplane> airplanes, List<Flight> flights);
    class Program
    {
        static void Main(string[] args)
        {
            Go();
        }

        private static void Go()
        {
            ReadFromFile read = new ReadFromFile();

            List<Airplane> airplaneList = new List<Airplane>();
            List<Flight> flightList = new List<Flight>();

            read.ReadFromAirplane(airplaneList);
            read.ReadFromFlight(flightList);

            Deleg add = (x, y) => StartWatching(x, y);

            add(airplaneList, flightList);

            Start(airplaneList, flightList);
        }

        private static void StartWatching(List<Airplane> airplanes, List<Flight> flights)
        {
            foreach (var f in flights)
            {
                foreach (var a in airplanes)
                {
                    if (f.typeAirplane == a.typeAirplane)
                    {
                        a.AddObserver(f.GetNameHandler());
                    }
                }
            }
        }

        private static void Start(List<Airplane> airplanes, List<Flight> flights)
        {
            bool exitFlag = false;

            while (!exitFlag)
            {

                foreach (var f in flights) f.Show();
                
                Menu();
                Parse(out int x);

                if (x == 1)
                {
                    Change(airplanes);
                    exitFlag = true;
                }
                else
                    Console.WriteLine("Try Again");
            }
            foreach (var f in flights) f.Show();
        }

        private static void Change(List<Airplane> airplanes)
        {
            Console.WriteLine("Do you want to change the price of a particular aircraft ? (Yes = 1/No = 2)");

            ParseYesNo(airplanes);
        }

        private static void ParseYesNo(List<Airplane> airplanes)
        {
            bool exitFlag = false;

            while (!exitFlag)
            {
                Parse(out int x);

                if (x == 1)
                {
                    exitFlag = true;
                    DialogWithType(airplanes);
                }
                else if (x == 2)
                {
                    exitFlag = true;
                    ChooseTiket (airplanes);
                }
                else
                    Console.WriteLine("This point do not exist!");
            }
        }

        private static void DialogWithType(List<Airplane> airplanes)
        {
            bool exitFlag = false;

            while (!exitFlag)
            {
                
                foreach (var a in airplanes) Console.Write($"\nType:{a.typeAirplane} Id:{a.id} ");
                Console.Write("Enter aircraft id number:");
                
                Parse(out int x);

                foreach (var plane in airplanes)
                {
                    if (plane.id == x)
                    {
                        ChooseTiket(airplanes, plane.typeAirplane);
                        exitFlag = true;
                    }
                }
            }
        }

        private static void ChooseTiket(List<Airplane> airplanes,string type = "")
        {
            bool exitFlag = false;
            while (!exitFlag)
            {
                Console.WriteLine("On which ticket do we increase the price (1 - econom | 2 - bisness| 3 - first class)?");

                Parse(out int x);

                if (x == 1 || x == 2 || x == 3)
                {
                    IncreasePrise(type, airplanes, x);
                    exitFlag = true;
                }
                else Console.WriteLine("Try again");
            }
        }

        private static void IncreasePrise(string typeAirplane, List<Airplane> airplanes, int typeTicket)
        {
            Console.WriteLine("how much do we increase the price ? ");

            Parse(out int x);

            if (typeAirplane == "")
                IncreasePriseToAll(airplanes, typeTicket, x);
            else
                IncreasePriseToSpecific(typeAirplane, airplanes, typeTicket, x);
        }
             
        private static void IncreasePriseToSpecific(string typeAirplane, List<Airplane> airplanes, int typeTicket, int addPrise )
        {
            foreach (var plane in airplanes)
            {
                if (plane.typeAirplane == typeAirplane)
                {
                    plane.prise[typeTicket - 1] += addPrise;
                    plane.Notify(plane);
                }
            }
        }

        private static void IncreasePriseToAll(List<Airplane> airplanes, int typeTicket, int addPrise)
        {
            int oldPrise = 0, newPrise = 0;

            foreach (var plane in airplanes)
            {
                oldPrise += plane.prise[typeTicket - 1];
                newPrise += plane.prise[typeTicket - 1] + addPrise;
                plane.prise[typeTicket - 1] += addPrise;
            }

            var procent = (newPrise - oldPrise / oldPrise) * 100;

            if (procent >= 15)
            {
                foreach (var a in airplanes) a.Notify(a);
            }
        }

        private static void Menu()
        {
            Console.WriteLine("1. Change the price of tikets for an airplanes\n\t Write specific point: ");
        }
        
        private static void Parse(out int x)
        {
            x = 0;

            while (!int.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Error! Enter again");
            }

        }
    }
}
