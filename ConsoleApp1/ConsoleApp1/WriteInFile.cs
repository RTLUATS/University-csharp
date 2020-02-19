using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ConsoleApp1
{
    class WriteInFile
    {
        internal void WriteInAirplane(List<Airplane> airplanes)
        {
            XmlDocument doc = new XmlDocument();
            
            doc.Load("AirplaneDB.xml");
            doc.RemoveAll();

            WriteA(doc, airplanes);

            doc.Save("AirplaneDB.xml");
        }

        private void WriteA(XmlDocument doc, List<Airplane> airplanes)
        {
            XmlElement rootCreate = doc.CreateElement("root");

            foreach (var plane in airplanes)
            {
                XmlElement planeElem = doc.CreateElement("Airplane");
                XmlAttribute idAtt = doc.CreateAttribute("id");
                XmlElement type = doc.CreateElement("Type");
                XmlElement econom = doc.CreateElement("EconomClass");
                XmlElement bisness = doc.CreateElement("BisnessClass");
                XmlElement first = doc.CreateElement("FirstClass");
                
                XmlText typeText = doc.CreateTextNode(plane.typeAirplane);
                XmlText economText = doc.CreateTextNode(Convert.ToString(plane.prise[0]));
                XmlText bisnessText = doc.CreateTextNode(Convert.ToString(plane.prise[1]));
                XmlText firstText = doc.CreateTextNode(Convert.ToString(plane.prise[2]));
                XmlText idText = doc.CreateTextNode(Convert.ToString(plane.id));

                idAtt.AppendChild(idText);
                planeElem.Attributes.Append(idAtt);
                type.AppendChild(typeText);
                econom.AppendChild(economText);
                bisness.AppendChild(bisnessText);
                first.AppendChild(firstText);
                planeElem.AppendChild(type);
                planeElem.AppendChild(econom);
                planeElem.AppendChild(bisness);
                planeElem.AppendChild(first);
                rootCreate.AppendChild(planeElem);
            }

        }

        internal void WriteInFlight(List<Flight> flights)
        {
            XmlDocument doc = new XmlDocument();

            doc.Load("FlightDB.xml");
            doc.RemoveAll();

            WriteF(doc, flights);

            doc.Save("FlightDB.xml");
        }

        private void WriteF(XmlDocument doc, List<Flight> flights)
        {
            XmlElement rootCreate = doc.CreateElement("root");

            foreach (var flight in flights)
            {
                XmlElement planeElem = doc.CreateElement("Airplane");
                XmlAttribute idAtt = doc.CreateAttribute("id");
                XmlElement destination = doc.CreateElement("Destination");
                XmlElement number = doc.CreateElement("Number");
                XmlElement type = doc.CreateElement("Type");
                XmlElement time = doc.CreateElement("Time");
                XmlElement date = doc.CreateElement("Date");
                XmlElement econom = doc.CreateElement("EconomClass");
                XmlElement bisness = doc.CreateElement("BisnessClass");
                XmlElement first = doc.CreateElement("FirstClass");
               
                XmlText destinationText = doc.CreateTextNode(flight.destination);
                XmlText numText = doc.CreateTextNode(Convert.ToString(flight.num));
                XmlText typeText = doc.CreateTextNode(flight.typeAirplane);
                XmlText timeText = doc.CreateTextNode(flight.departureTime);
                XmlText dateText = doc.CreateTextNode(flight.departureDate);
                XmlText economText = doc.CreateTextNode(Convert.ToString(flight.prise[0]));
                XmlText bisnessText = doc.CreateTextNode(Convert.ToString(flight.prise[1]));
                XmlText firstText = doc.CreateTextNode(Convert.ToString(flight.prise[2]));
                XmlText idText = doc.CreateTextNode(Convert.ToString(flight.id));

                idAtt.AppendChild(idText);
                planeElem.Attributes.Append(idAtt);
                destination.AppendChild(destinationText);
                number.AppendChild(numText);
                type.AppendChild(typeText);
                time.AppendChild(timeText);
                date.AppendChild(dateText);
                econom.AppendChild(economText);
                bisness.AppendChild(bisnessText);
                first.AppendChild(firstText);
                rootCreate.AppendChild(planeElem);
                planeElem.AppendChild(destination);
                planeElem.AppendChild(number);
                planeElem.AppendChild(type);
                planeElem.AppendChild(time);
                planeElem.AppendChild(date);
                planeElem.AppendChild(econom);
                planeElem.AppendChild(bisness);
                planeElem.AppendChild(first);
            }

        }

    }
}
