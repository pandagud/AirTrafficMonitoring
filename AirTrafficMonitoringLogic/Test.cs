using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace AirTrafficMonitoringLogic
{
    public class Test
    {
        private TransponderReceiver.TransponderReceiverFactory receiver = new TransponderReceiverFactory();

        public void getSomething()
        {
            var something = receiver;
        }
    }
}
