using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoringLogic.Interface
{
    public interface IMonitoringAirSpace
    {
        void Monitor(List<Aircraft> data);
    }
}
