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
        private AircraftObjectsUtility aircraftObjectsUtility;
        private IPrint _print;
       

        public RecieveAircrafts(ITransponderReceiver receiver,IPrint print)
        {
            _print = print;
                aircraftObjectsUtility = new AircraftObjectsUtility();
            
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
            
            var localListofAircraftObjects = aircraftObjectsUtility.getListofAircraftObjects(data.TransponderData);
           
            _print.PrintData(localListofAircraftObjects);
            
        }

       


        public event EventHandler<RawTransponderDataEventArgs> TransponderDataReady;


    }
  
}
