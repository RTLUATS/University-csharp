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

        public void ChangePrise(Airplane airplane, string tiket, int priseNew , int key = 0)
        {
            if (key == 0)
            {

                if (tiket == "эконом")
                {
                    prise[0] += priseNew; 
                }
                else if (tiket == "бизнесс")
                {
                    prise[1] += priseNew;
                }
                else
                {
                    prise[2] += priseNew;
                }
            }
            else
            {
                if (tiket == "эконом")
                {
                    prise[0] += priseNew;
                }
                else if (tiket == "бизнесс")
                {
                    prise[1] += priseNew;
                }
                else
                {
                    prise[2] += priseNew;
                }
                NotifyObservers(airplane);
            }
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
