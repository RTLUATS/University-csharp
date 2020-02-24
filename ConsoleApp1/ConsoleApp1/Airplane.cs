using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Airplane : IObserverable // наблюдаемый объект
    {
        internal  int[] prise { set; get; }
        internal string typeAirplane { set; get; }
        internal int id { set; get; }

        private List<IObserver> observers;

        public Airplane()
        {
            observers = new List<IObserver>();
            prise = new int[3];
        }

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void NotifyObservers(Airplane airplane)
        {
            foreach(IObserver o  in observers)
            {
                o.Update(airplane);
            }
        }

        public void RemoveObserver (IObserver observer)
        {
            observers.Remove(observer);
        }

    }
}
