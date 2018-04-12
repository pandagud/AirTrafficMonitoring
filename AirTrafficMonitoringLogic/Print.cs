using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic;
using AirTrafficMonitoringLogic.Interface;

namespace AirTrafficMonitoringLogic
{
    public class Print:IPrint,IObserver
    {
        public Print(IRecieveAircrafts IRA)
        {
            //IRA.TransponderDataObjectReady += PrintData; ;
            
        }


        public void PrintData(List<Aircraft> data)
        {
            //Console.Clear();
            //foreach (var e in data)
            //{
            //    Console.WriteLine(e.ToString());
            //}
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
