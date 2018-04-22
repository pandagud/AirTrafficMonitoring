using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic;
using AirTrafficMonitoringLogic.Interface;

namespace AirTrafficMonitoring
{
    class Program
    {
        
        static void Main(string[] args)
        {


           
            DTO.ListofAircraftObj = new List<Aircraft>();
            var myReciever = TransponderReceiver.TransponderReceiverFactory.CreateTransponderDataReceiver();
            
            AircraftObjectsUtility _aircraftObjectsUtility = new AircraftObjectsUtility();
            IRecieveAircrafts recieveAircrafts = new RecieveAircrafts(myReciever, _aircraftObjectsUtility);

            IObserver _print = new Print(recieveAircrafts);
            MonitoringAirSpace _monitoringAirSpace = new MonitoringAirSpace(recieveAircrafts);
            _monitoringAirSpace.Attach(_print);
            SeparationEventToFileLog testSepToFileLog = new SeparationEventToFileLog();
            testSepToFileLog.writeToFile();
            Console.ReadLine();

        }

        
       

       

    }
    }

