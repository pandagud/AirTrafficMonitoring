using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic;

namespace AirTrafficMonitoring
{
    class Program
    {
        
        static void Main(string[] args)
        {

          
            var myReciever = TransponderReceiver.TransponderReceiverFactory.CreateTransponderDataReceiver();
            myReciever.TransponderDataReady += MyReceiver_TransportData;
            Console.ReadKey();

        }

        private static void MyReceiver_TransportData(object sender, TransponderReceiver.RawTransponderDataEventArgs e)
        {
            var recivedData = e.TransponderData;
            PrintData(recivedData);
        }

        private static void PrintData(List<string> data)
        {
            foreach (var e in data)
            {
                Console.WriteLine(e);
            }
        }

       

       

    }
    }

