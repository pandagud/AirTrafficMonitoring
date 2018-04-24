using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic;
using AirTrafficMonitoringLogic.AircraftUtillity;
using AirTrafficMonitoringLogic.Interface;
using AirTrafficMonitoringLogic.Utillity;

namespace AirTrafficMonitoring
{
    class Program
    {
        
        static void Main(string[] args)
        {


           
           
            var myReciever = TransponderReceiver.TransponderReceiverFactory.CreateTransponderDataReceiver();
            
            AircraftObjectsUtility _aircraftObjectsUtility = new AircraftObjectsUtility();
            ICourseAndVelocityCalculator _courseAndVelocityCalculator = new CourseAndVelocityCalculator();
            IRecieveAircrafts recieveAircrafts = new RecieveAircrafts(myReciever, _aircraftObjectsUtility, _courseAndVelocityCalculator);

            IObserver _print = new Print();
            MonitoringAirSpace _monitoringAirSpace = new MonitoringAirSpace(recieveAircrafts);
            _monitoringAirSpace.Attach(_print);
            CreateSeparationEvents _cse = new CreateSeparationEvents();
            _monitoringAirSpace.Attach(_cse);
            IToLogFile file = new SeparationEventToFileLog();
            IPrint _print2 = new Print();
            HandleSeparationEvents hse = new HandleSeparationEvents(_cse, file, _print2);
            _cse.Attach(hse);
            Console.ReadLine();

        }

        
       

       

    }
    }

