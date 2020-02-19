using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Flight: IObserver // наблюдатель
    {
        internal int num { set; get; }
        internal string typeAirplane { set; get; }
        internal string destination { set; get; }
        internal string departureDate { set; get; }
        internal string departureTime { set; get; }
        internal int[] prise { set; get; }
        internal int id { set; get; }
        
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
