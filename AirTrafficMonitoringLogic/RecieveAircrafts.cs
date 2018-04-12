using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic.Interface;
using TransponderReceiver;

namespace AirTrafficMonitoringLogic
{
    public class RecieveAircrafts :IRecieveAircrafts
    {
        List<String> localList = new List<string>();
       // private IPrint _print;
        private IAirCraftObjectsUtility _aircraftObjectsUtility;
        public List<Aircraft> localListofAircraftObjects;
        
        public bool called = false;



        public RecieveAircrafts(ITransponderReceiver receiver,IAirCraftObjectsUtility aircraftObjectsUtility)
        {
           //_print = print;
            _aircraftObjectsUtility = aircraftObjectsUtility;


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

            localListofAircraftObjects = _aircraftObjectsUtility.getListofAircraftObjects(data.TransponderData);
           
            var handler = TransponderDataObjectReady;
            handler?.Invoke(localListofAircraftObjects);


          
            
        }

       


        public event EventHandler<RawTransponderDataEventArgs> TransponderDataReady;
        public delegate void MyEventHandler(List<Aircraft> data);
        public event MyEventHandler TransponderDataObjectReady;

       


    }

   
}
