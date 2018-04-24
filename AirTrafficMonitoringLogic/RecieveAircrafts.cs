using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic.AircraftUtillity;
using AirTrafficMonitoringLogic.Interface;
using TransponderReceiver;

namespace AirTrafficMonitoringLogic
{
    public class RecieveAircrafts :IRecieveAircrafts
    {
        List<String> localList = new List<string>();
       // private IPrint _print;
        private IAirCraftObjectsUtility _aircraftObjectsUtility;
        public List<Aircraft> ListofAircraftObjects;
        private ICourseAndVelocityCalculator _courseAndVelocityCalculator;


        public bool called = false;



        public RecieveAircrafts(ITransponderReceiver receiver,IAirCraftObjectsUtility aircraftObjectsUtility,ICourseAndVelocityCalculator courseAndVelocityCalculator)
        {

           //_print = print;
            _aircraftObjectsUtility = aircraftObjectsUtility;
            _courseAndVelocityCalculator = courseAndVelocityCalculator;

            receiver.TransponderDataReady += MyReceiver_TransportData;
        }
        public void MyReceiver_TransportData(object sender, TransponderReceiver.RawTransponderDataEventArgs e)
        {
            var recivedData = e.TransponderData;
      

            UpdateTransponderData(new RawTransponderDataEventArgs(recivedData));      
            
        
        }
        public void UpdateTransponderData(RawTransponderDataEventArgs data)
        {
            called = true;

            ListofAircraftObjects = _aircraftObjectsUtility.getListofAircraftObjects(data.TransponderData);
           _courseAndVelocityCalculator.CalculateBoth(ListofAircraftObjects);
            var handler = TransponderDataObjectReady;
            handler?.Invoke(ListofAircraftObjects);
            
        }

       


        public event EventHandler<RawTransponderDataEventArgs> TransponderDataReady;
        public delegate void MyEventHandler(List<Aircraft> data);
        public event MyEventHandler TransponderDataObjectReady;

       


    }

   
}
