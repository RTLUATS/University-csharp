using System;
using System.Collections.Generic;
using System.Xml;
namespace ConsoleApp1
{
    class ReadFromFile
    {
        internal void ReadFromAirplane(List<Airplane> airplanes)
        {
            XmlDocument doc = new XmlDocument();

            doc.Load(@"C:\Users\jtmotn\source\repos\ConsoleApp1\ConsoleApp1\AirplaneDB.xml");

            int index = 0;

            foreach (XmlNode node in doc.DocumentElement)
            {
                airplanes.Add(new Airplane());

                XmlNode idAir = node.Attributes.GetNamedItem("id");
                if (idAir != null)
                    airplanes[index].id = Convert.ToInt32(idAir.Value);

                foreach (XmlNode child in doc.ChildNodes)
                {
                    BranchingA(child, index ,airplanes);
                    
                }
            }

        }
        
        private void BranchingA(XmlNode child,int index, List<Airplane> airplanes)
        {
            if (child.Name == "Type")
            {
                airplanes[index].typeAirplane = child.InnerText;
            }
            else if (child.Name == "EconomClass")
            {
                airplanes[index].prise[0] = Convert.ToInt32(child.InnerText);
            }
            else if (child.Name == "BisnessClass")
            {
                airplanes[index].prise[1] = Convert.ToInt32(child.InnerText);
            }
            else if (child.Name == "FirstClass")
            {
                airplanes[index].prise[2] = Convert.ToInt32(child.InnerText);
            }

        }

        internal void ReadFromFlight(List<Flight> flights)
        {
            XmlDocument doc = new XmlDocument();

            doc.Load(@"C:\Users\jtmotn\source\repos\ConsoleApp1\ConsoleApp1\FlightDB.xml");

            int index = 0;

            foreach (XmlNode node in doc.DocumentElement)
            {
                flights.Add(new Flight());

                XmlNode idFl = node.Attributes.GetNamedItem("id");
                if (idFl != null)
                    flights[index].id = Convert.ToInt32(idFl.Value);

                foreach (XmlNode child in doc.ChildNodes)
                {
                    BranchingB(child, index, flights);

                }
            }
        }

        private void BranchingB(XmlNode child, int index, List<Flight> flights)
        {
            if (child.Name == "Destination")
            {
                flights[index].destination = child.InnerText;
            }
            else if (child.Name == "Number")
            {
                flights[index].num = Convert.ToInt32(child.InnerText);
            }
            else if (child.Name == "Type")
            {
                flights[index].typeAirplane = child.InnerText;
            }
            else if (child.Name == "Time")
            {
                flights[index].departureTime = child.InnerText;
            }
            else if (child.Name == "Date")
            {
                flights[index].departureDate = child.InnerText;
            }
            else if (child.Name == "EconomClass")
            {
                flights[index].prise[0] = Convert.ToInt32(child.InnerText);
            }
            else if (child.Name == "BisnessClass")
            {
                flights[index].prise[1] = Convert.ToInt32(child.InnerText);
            }
            else if (child.Name == "FirstClass")
            {
                flights[index].prise[2] = Convert.ToInt32(child.InnerText);
            }

        }

    }
}
