using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic;

namespace AirTrafficMonitoringLogic
{
    public class Print
    {
        public static void PrintData(List<Aircraft> data)
        {
            Console.Clear();
            foreach (var e in data)
            {
                Console.WriteLine(e.ToString());
            }

        }
    }
}
