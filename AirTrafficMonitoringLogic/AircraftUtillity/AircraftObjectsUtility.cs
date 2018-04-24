using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic.Interface;

namespace AirTrafficMonitoringLogic
{
    public class AircraftObjectsUtility:IAirCraftObjectsUtility
    {
        private List<Aircraft> aircrafts;
        public List<Aircraft> getListofAircraftObjects(List<string> data)
        {
            
            aircrafts = new List<Aircraft>();  
            
             for (int i = 0; i < data.Count; i++)
             {
                 var localarray = SplitToArray(data,i);
                 var localAircraftobject = ArrayToAircraftObject(localarray);
                 aircrafts.Add(localAircraftobject);

             }

           
            return aircrafts;
        }

        public string[] SplitToArray(List<string>data, int index)
        {
            string[] split = new string[data.Count];
            string element = data[index];
            for (int j = 0; j < element.Length; j++)
            {
                split = data[index].Split(new char[] { ';' });

            }

            return split;

        }

        public Aircraft ArrayToAircraftObject(string[] data)
        {
            Aircraft currentAircraft = new Aircraft(data[0], Int32.Parse(data[1]), Int32.Parse(data[2]), Int32.Parse(data[3]), DateTime.ParseExact(data[4], "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            return currentAircraft;
        }

       
    }
}
