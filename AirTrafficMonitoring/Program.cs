using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic;

namespace AirTrafficMonitoring
{
    class Program
    {
        
        static void Main(string[] args)
        {


           
            DTO.ListofAircraftObj = new List<Aircraft>();
            var myReciever = TransponderReceiver.TransponderReceiverFactory.CreateTransponderDataReceiver();
            Print _print = new Print();
            AircraftObjectsUtility _aircraftObjectsUtility = new AircraftObjectsUtility();
            RecieveAircrafts recieveAircrafts = new RecieveAircrafts(myReciever, _print, _aircraftObjectsUtility);
           
            Console.ReadLine();

        }

        
       

       

    }
    }

