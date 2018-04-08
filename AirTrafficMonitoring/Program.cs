using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic;

namespace AirTrafficMonitoring
{
    class Program
    {
        
        static void Main(string[] args)
        {


            //var myReciever = TransponderReceiver.TransponderReceiverFactory.CreateTransponderDataReceiver();
            //myReciever.TransponderDataReady += MyReceiver_TransportData;
            DTO.ListofAircraftObj = new List<Aircraft>();
            RecieveAircrafts recieveAircrafts = new RecieveAircrafts();
            //do
            //{
            //    while (!Console.KeyAvailable)
            //    {
                    
            //    }
            //} while (Console.ReadKey(true).Key != ConsoleKey.Escape);


            //AircraftObjectsUtility convertToAircraftObjects = new AircraftObjectsUtility();
            //var list = convertToAircraftObjects.getListofAircraftObjects();
            //DTO.ListofAircraftObj = list;
            Console.ReadLine();

        }

        //private static void MyReceiver_TransportData(object sender, TransponderReceiver.RawTransponderDataEventArgs e)
        //{
        //    var recivedData = e.TransponderData;
        //    PrintData(recivedData);
        //}

        //private static void PrintData(List<Aircraft> data)
        //{
        //    foreach (var e in data)
        //    {
        //        Console.WriteLine("Tag name is: "+e._tag+" x coordinate is :"+e._xcoordinate+ " y coordinate is :"+e._ycoordinate+" altitude is :"+e._altitude+ " timestamp is :"+e._timestamp);
        //    }
        //}

       

       

    }
    }

