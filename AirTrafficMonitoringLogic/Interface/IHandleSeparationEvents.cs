using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic.AircraftUtillity;

namespace AirTrafficMonitoringLogic.Interface
{
    public interface IHandleSeparationEvents
    {
        void Update(List<SeparationEventArgs> s);
        void writeNewEventsToLog(SeparationEventArgs se);
        void checkForDeactivatedEvents(List<SeparationEventArgs> s);
        void checkForNewEvents(List<SeparationEventArgs> s);
    }
}
