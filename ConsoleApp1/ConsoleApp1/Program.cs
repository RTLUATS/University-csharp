using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadFromFile read = new ReadFromFile();
            
            List<Airplane> airplaneList = new List<Airplane>();
            List<Flight> flightList = new List<Flight>();

            read.ReadFromAirplane(airplaneList);
            read.ReadFromFlight(flightList);
           
            Start(airplaneList, flightList);
           
        }

        static private void Start(List<Airplane> airplanes, List<Flight> flights)
        {

            foreach (var f in flights)
            {
                foreach(var a in airplanes)
                {
                    if ( f.typeAirplane == a.typeAirplane)
                    {
                        a.AddObserver(f);
                    }
                }
            }

            Menu();
            Parse(out int x);

            switch (x)
            {
                case 1: Change(airplanes, flights);
                    break;
                default: Console.WriteLine("Такого пункта нет");
                    break;
            }

        }

        static private void Change(List<Airplane> airplanes, List<Flight> flights)
        {

            Console.WriteLine("Вы хотите изменить цены на билет у конкретного самолёта?(Да/Нет)");

            Parse(out string x);

            Branching(x, airplanes, flights);
            
        }

        static private void Branching(string x, List<Airplane> airplanes, List<Flight> flights)
        {

            var count = 0;

            if(x == "Да")
            {
                while (count == 0)
                {

                    Console.WriteLine("Введите тип самолёта:");

                    string typePlane = Console.ReadLine();

                    foreach (var air in airplanes)
                    {
                        if (air.typeAirplane == typePlane)
                        {
                            count++;
                            Console.WriteLine("Введите название билета который вы хотите изменить(эконом/бизнесс/первый)");
                            
                            Tiket(airplanes, flights, typePlane);
                        }

                    }
                    if (count == 0) Console.WriteLine("Такого самолёта нет!Введите ещё раз");
                    
                }
            }
            else
            {
                Console.WriteLine("Введите название билета который вы хотите изменить(эконом/бизнесс/первый)");
                
                Tiket( airplanes, flights);
            }

        }

        static private void Tiket(List<Airplane> airplanes, List<Flight> flights, string typePlane = "-1")
        {
            int oldPrise = 0, newPrise = 0;
            bool exitFlag = false;
            string tiket = "";

            while (!exitFlag)
            {
                tiket = Console.ReadLine();

                if (tiket == "эконом" || tiket == "бизнесс" || tiket == "первый")
                    exitFlag = true;
                else
                    Console.WriteLine("Введите ещё раз");
                
            }

            Console.WriteLine("Введите на сколько $ увеличится цена");
           
            Parse(out int priseNew);

            if(typePlane == "-1")
            {

                foreach (var plane in airplanes)
                {
                    if (tiket == "эконом")
                    {
                        oldPrise += plane.prise[0];
                        newPrise += plane.prise[0] + priseNew;
                        
                        plane.ChangePrise(plane, tiket, newPrise);
                    }
                    else if (tiket == "бизнесс")
                    {
                        oldPrise += plane.prise[1];
                        newPrise += plane.prise[1] + priseNew;
                        
                        plane.ChangePrise(plane, tiket, priseNew);
                    }
                    else
                    {
                        oldPrise += plane.prise[2];
                        newPrise += plane.prise[2] + priseNew;

                        plane.ChangePrise(plane, tiket, priseNew);
                    }

                }

                var procent = (newPrise - oldPrise / oldPrise) * 100;

                if (procent >= 15)
                {
                    foreach (var a in airplanes) a.NotifyObservers(a);   
                }

            }
            else
            {
                foreach (var plane in airplanes)
                {
                    if (tiket == "эконом" && plane.typeAirplane == typePlane)
                    {
                        plane.ChangePrise(plane, tiket, priseNew,1);
                    }
                    else if (tiket == "бизнесс" && plane.typeAirplane == typePlane)
                    {
                        plane.ChangePrise(plane, tiket, priseNew,1);
                    }
                    else if(plane.typeAirplane == typePlane)
                    {
                        plane.ChangePrise(plane, tiket, priseNew,1);
                    }
                }

            }

        }

        static private void Menu()
        {
            Console.WriteLine("1. Bla\n\t Bla: ");
        }

        static private void Parse(out string x)
        {
            x = "";
            bool exitFlag = false;


            while (!exitFlag)
            {
                x = Console.ReadLine();

                if (x == "Да" || x == "Нет") 
                {
                    exitFlag = true;
                }
                else
                {
                    Console.WriteLine("Ошибка ввода");
                }
            }

        }


        static private void Parse(out int x)
        {
            x = 0;

            while (!int.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Введите ещё раз!");
            }

        }
    }
}
