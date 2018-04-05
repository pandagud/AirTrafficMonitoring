﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace AirTrafficMonitoringIntegrationTest.TransponderReceiverFactory
{
    public abstract class TransponderReceiverFactory
    {
        public abstract ITransponderReceiver CreateTransponderDataReceiver();
    }

}
