using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace AirTrafficMonitoringLogic
{
    public class Test :ITransponderReceiver
    {
        private TransponderReceiver.TransponderReceiverFactory receiver = new TransponderReceiverFactory();
        private TransponderDataEventArgs eventArgs = new TransponderDataEventArgs();
        private RawTransponderDataEventArgs rawTransponderData;
        public event EventHandler<RawTransponderDataEventArgs> TransponderDataReady;

        public Test()
        {
            var reciever = TransponderReceiverFactory.CreateTransponderDataReceiver();
            reciever.TransponderDataReady += getSomething;

        }

        public void SeeData()
        {
           
        }

        public static void getSomething(object o, RawTransponderDataEventArgs args)
        {
            var data = args.TransponderData;


        }

       
    }
}
