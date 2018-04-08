using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic;
using AirTrafficMonitoringLogic.Interface;

namespace AirTrafficMonitoringLogic
{
    public class Print:IPrint
    {

        void IPrint.PrintData(List<Aircraft> data)
        {
            Console.Clear();
            foreach (var e in data)
            {
                Console.WriteLine(e.ToString());
            }
        }

       
    }
}
