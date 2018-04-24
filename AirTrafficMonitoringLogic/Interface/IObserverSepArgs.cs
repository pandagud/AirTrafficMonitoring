using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic.AircraftUtillity;
using AirTrafficMonitoringLogic.Utillity;

namespace AirTrafficMonitoringLogic.Interface
{
    public interface IObserverSepArgs
    {
        void Update(List<SeparationEventArgs> s); // Indsæt at den notify'er med en liste af aircrafts
    }
}
