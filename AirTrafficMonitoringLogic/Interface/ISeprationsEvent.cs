using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic.AircraftUtillity;

namespace AirTrafficMonitoringLogic.Interface
{
    public interface ISeprationsEvent
    {
        event EventHandler<SeparationEventArgs> SeprationsEvent;
    }
}
