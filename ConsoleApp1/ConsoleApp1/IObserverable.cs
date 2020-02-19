using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    interface IObserverable
    {
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers(Airplane airplane);

    }
}
