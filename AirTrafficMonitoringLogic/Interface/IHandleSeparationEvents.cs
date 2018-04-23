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
        void HandleEvents(object sender, SeparationEventArgs se);
        void writeNewEventsToLog(SeparationEventArgs se);
        void updateConsole();
        void checkForDeactivatedEvents(SeparationEventArgs se);
    }
}
