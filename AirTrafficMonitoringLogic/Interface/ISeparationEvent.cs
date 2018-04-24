using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic.AircraftUtillity;

namespace AirTrafficMonitoringLogic.Interface
{
    public interface ISeparationEvent
    {
        void Update(List<Aircraft> s);
        bool checkHorizontalSeparation(Aircraft s, Aircraft s1);

        bool checkAltitude(Aircraft s, Aircraft s1);


    }
}
