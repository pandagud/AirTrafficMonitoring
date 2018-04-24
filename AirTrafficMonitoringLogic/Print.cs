using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic;
using AirTrafficMonitoringLogic.AircraftUtillity;
using AirTrafficMonitoringLogic.Interface;

namespace AirTrafficMonitoringLogic
{
    public class Print:IPrint,IObserver
    {


        public void PrintData(SeparationEventArgs data)
        {
            Console.WriteLine(data.ToString());
        }

        public void Update(List<Aircraft> s)
        {
            try
            {
                Console.Clear();
            }
            catch (Exception e)
            {
                // Had a problem here. I wanted to make an integration test from Monitoring To Print. But i was unable to "confirm" the connection because i was getting an System.IO exception when i tried using a streamwriter as Console.Output. 

            }
            
            foreach (var e in s)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
