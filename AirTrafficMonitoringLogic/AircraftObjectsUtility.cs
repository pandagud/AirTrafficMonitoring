using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoringLogic
{
    public class AircraftObjectsUtility
    {
        private List<Aircraft> aircrafts;
        public List<Aircraft> getListofAircraftObjects()
        {
            
            aircrafts = new List<Aircraft>();
            bool firsttime = true;
             for (int i = 0; i < DTO.ListofRecovedData.Count; i++)
             {
                 var localarray = SplitToArray(i);
                 var localAircraftobject = ArrayToAircraftObject(localarray);
                 aircrafts.Add(localAircraftobject);

             }

           
            return aircrafts;
        }

        public string[] SplitToArray( int index)
        {
            string[] split = new string[DTO.ListofRecovedData.Count];
            string element = DTO.ListofRecovedData[index];
            for (int j = 0; j < element.Length; j++)
            {
                split = DTO.ListofRecovedData[index].Split(new char[] { ';' });

            }

            return split;

        }

        public Aircraft ArrayToAircraftObject(string[] data)
        {
            Aircraft currentAircraft = new Aircraft(data[0], Int32.Parse(data[1]), Int32.Parse(data[2]), Int32.Parse(data[3]), data[4]);
            return currentAircraft;
        }

        //public List<Aircraft> AddAircrafttoList(Aircraft data)
        //{
        //    if (aircrafts.Count == 0)
        //    {
        //        aircrafts.Add(data);
        //    }
        //    else
        //    {
        //        foreach (var xAircraft in aircrafts.ToList())
        //        {
        //            if (data._tag == xAircraft._tag)
        //            {
        //                xAircraft._xcoordinate = data._xcoordinate;
        //                xAircraft._ycoordinate = data._ycoordinate;
        //                xAircraft._timestamp = data._timestamp;
        //                xAircraft._altitude = data._altitude;
        //            }
        //            else
        //            {
        //                aircrafts.Add(data);
        //            }
        //        }
        //    }

        //    return aircrafts;

        //}
    }
}
