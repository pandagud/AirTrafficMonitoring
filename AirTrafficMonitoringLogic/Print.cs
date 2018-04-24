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
            Console.Clear();
            foreach (var e in s)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
