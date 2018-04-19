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
        private DirectionAndSpeedCalculator _directionAndSpeedCalculator;
        private List<Aircraft> LocalList;


        public bool called = false;



        public RecieveAircrafts(ITransponderReceiver receiver,IAirCraftObjectsUtility aircraftObjectsUtility)
        {

           //_print = print;
            _aircraftObjectsUtility = aircraftObjectsUtility;
            _directionAndSpeedCalculator = new DirectionAndSpeedCalculator();

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
            LocalList = new List<Aircraft>();
            LocalList = ListofAircraftObjects;
            _directionAndSpeedCalculator.CalculatBoth(LocalList);
            var handler = TransponderDataObjectReady;
            handler?.Invoke(LocalList);


          
            
        }

       


        public event EventHandler<RawTransponderDataEventArgs> TransponderDataReady;
        public delegate void MyEventHandler(List<Aircraft> data);
        public event MyEventHandler TransponderDataObjectReady;

       


    }

   
}
