using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ConsoleApp1
{

    class Flight // наблюдатель
    {
        private NameHandler name ;

        internal int num { set; get; }

        internal string typeAirplane { set; get; }
        
        internal string destination { set; get; }
        
        internal string departureDate { set; get; }
        
        internal string departureTime { set; get; }
        
        internal int[] prise { set; get; }

        internal int id { set; get; }

        public void  Show()
        {
            Console.WriteLine("__________________________________________________________________________");
            Console.WriteLine($"Type:{typeAirplane} Number:{num} Depatrture Time:{departureTime}\n" +
                              $"DepartureDate :{departureDate} Destination: {destination}\n" +
                              $"Econom Class:{prise[0]} Bisness Class:{prise[1]} First Class {prise[2]}");
        }

        public NameHandler GetNameHandler()
        {
            name -= Update;
            name += Update;
            return name;
        }

        public Flight()
        {
            prise = new int[3];
        }
       
        public void Update(Airplane airplane)
        {
            airplane.prise.CopyTo(prise,0);
        }

    }
}
