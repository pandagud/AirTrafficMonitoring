using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic.Interface;

namespace AirTrafficMonitoringLogic.AircraftUtillity
{
    public class SeparationEventArgs : EventArgs
    {
        private DateTime _separationEventTime;
        private string _tag1;
        private string _tag2;

        public SeparationEventArgs(DateTime time, string tag1, string tag2)
        {
            _separationEventTime = time;
            _tag1 = tag1;
            _tag2 = tag2;
        }

        public DateTime getTime()
        {
            return _separationEventTime;
        }

        public string getTags()
        {
            return _tag1 + _tag2;
        }
    }
}
