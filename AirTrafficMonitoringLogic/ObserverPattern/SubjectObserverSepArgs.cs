using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic.AircraftUtillity;
using AirTrafficMonitoringLogic.Interface;

namespace AirTrafficMonitoringLogic.Utillity
{
    public abstract class SubjectObserverSepArgs
    {
        List<IObserverSepArgs> ObserverList;
        public SubjectObserverSepArgs()
        {
                ObserverList = new List<IObserverSepArgs>();
        }
        


        public void Attach(IObserverSepArgs o)
        {
            ObserverList.Add(o);
        }

        public void Detach(IObserverSepArgs o)
        {
            ObserverList.Remove(o);
        }

        public void Notify(List<SeparationEventArgs> s)
        {
            foreach (var item in ObserverList)
            {
                item.Update(s);
            }
        }

    }
}
