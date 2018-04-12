using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic.Utillity;

namespace AirTrafficMonitoringLogic.Interface
{
    public interface IObserver
    {
        void Update(List<Aircraft> s); // Indsæt at den notify'er med en liste af aircrafts
    }
}
