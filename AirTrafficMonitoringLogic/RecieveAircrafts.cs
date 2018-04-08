using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoringLogic
{
    public class RecieveAircrafts
    {
       
        public RecieveAircrafts()
        {
            var myReciever = TransponderReceiver.TransponderReceiverFactory.CreateTransponderDataReceiver();
            myReciever.TransponderDataReady += MyReceiver_TransportData;
        }
        public static void MyReceiver_TransportData(object sender, TransponderReceiver.RawTransponderDataEventArgs e)
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
            AircraftObjectsUtility aircraftObjectsUtility = new AircraftObjectsUtility();
            var localListofAircraftObjects =aircraftObjectsUtility.getListofAircraftObjects();
            DTO.ListofAircraftObj = localListofAircraftObjects;
            PrintData(localListofAircraftObjects);

        }
        private static void PrintData(List<Aircraft> data)
        {
            Console.Clear();
            foreach (var e in data)
            {
                Console.WriteLine(e.ToString());
            }
            
        }


    }
}
