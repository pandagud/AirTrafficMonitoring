using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace AirTrafficMonitoringLogic
{
    public class RecieveAircrafts 
    {
        List<String> localList = new List<string>();
        private AircraftObjectsUtility aircraftObjectsUtility;
       

        public RecieveAircrafts(ITransponderReceiver receiver)
        {
                aircraftObjectsUtility = new AircraftObjectsUtility();
            
            receiver.TransponderDataReady += MyReceiver_TransportData;
        }
        public void MyReceiver_TransportData(object sender, TransponderReceiver.RawTransponderDataEventArgs e)
        {
            var recivedData = e.TransponderData;
            if (DTO.ListofRecovedData == null)
            {
                DTO.ListofRecovedData = new List<string>();
                DTO.ListofRecovedData = recivedData;
            }
            else
            {
                DTO.ListofRecovedData = recivedData;
            }

            UpdateTransponderData(new RawTransponderDataEventArgs(recivedData));
            //localList = recivedData;
        
        }
        private void UpdateTransponderData(RawTransponderDataEventArgs data)
        {
            var handler = TransponderDataReady;
            handler?.Invoke(this, data);
            DTO.ListofRecovedData = data.TransponderData;
            var localListofAircraftObjects = aircraftObjectsUtility.getListofAircraftObjects(data.TransponderData);
            DTO.ListofAircraftObj = localListofAircraftObjects;
            Print.PrintData(localListofAircraftObjects);
            
        }

       


        public event EventHandler<RawTransponderDataEventArgs> TransponderDataReady;


    }
  
}
