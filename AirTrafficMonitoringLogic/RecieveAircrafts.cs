using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic.Interface;
using TransponderReceiver;

namespace AirTrafficMonitoringLogic
{
    public class RecieveAircrafts 
    {
        List<String> localList = new List<string>();
        private IPrint _print;
        private IAirCraftObjectsUtility _aircraftObjectsUtility;
        public List<Aircraft> localListofAircraftObjects;



        public RecieveAircrafts(ITransponderReceiver receiver,IPrint print,IAirCraftObjectsUtility aircraftObjectsUtility)
        {
            _print = print;
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
            var handler = TransponderDataReady;
            handler?.Invoke(this, data);

            localListofAircraftObjects = _aircraftObjectsUtility.getListofAircraftObjects(data.TransponderData);
           
            _print.PrintData(localListofAircraftObjects);
            
        }

       


        public event EventHandler<RawTransponderDataEventArgs> TransponderDataReady;


    }
  
}
