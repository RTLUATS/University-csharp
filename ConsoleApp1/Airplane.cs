using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal delegate void NameHandler(Airplane plane);

    class Airplane  // наблюдаемый объект
    {
        private event NameHandler nameHandler;
       
        internal  int[] prise { set; get; }
        
        internal string typeAirplane { set; get; }
        
        internal int id { set; get; }

        public Airplane()
        {
            prise = new int[3];
        }

        public void AddObserver(NameHandler nameHandler)
        {
            this.nameHandler += nameHandler;
        }

        public void RemoveObserver(NameHandler nameHandler)
        {
            this.nameHandler -= nameHandler;
        }

        public void Notify(Airplane plane)
        {
            nameHandler?.Invoke(plane);
        }


    }
}
