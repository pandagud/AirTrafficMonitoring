using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic;
using AirTrafficMonitoringLogic.AircraftUtillity;
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
            ICourseAndVelocityCalculator _courseAndVelocityCalculator = new CourseAndVelocityCalculator();
            IRecieveAircrafts recieveAircrafts = new RecieveAircrafts(myReciever, _aircraftObjectsUtility, _courseAndVelocityCalculator);

            IObserver _print = new Print(recieveAircrafts);
            MonitoringAirSpace _monitoringAirSpace = new MonitoringAirSpace(recieveAircrafts);
            _monitoringAirSpace.Attach(_print);
            CreateSeparationEvents _cse = new CreateSeparationEvents();
            _monitoringAirSpace.Attach(_cse);
            IToLogFile file = new SeparationEventToFileLog();
            
            HandleSeparationEvents hse = new HandleSeparationEvents(_cse, file);
            _cse.Attach(hse);
            Console.ReadLine();

        }

        
       

       

    }
    }

