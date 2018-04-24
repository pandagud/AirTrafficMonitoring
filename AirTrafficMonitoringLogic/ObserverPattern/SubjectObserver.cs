using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic.Interface;

namespace AirTrafficMonitoringLogic.Utillity
{
    public abstract class SubjectObserver
    {
        List<IObserver> ObserverList;
        public SubjectObserver()
        {
                ObserverList = new List<IObserver>();
        }
        


        public void Attach(IObserver o)
        {
            ObserverList.Add(o);
        }

        public void Detach(IObserver o)
        {
            ObserverList.Remove(o);
        }

        public void Notify(List<Aircraft> s)
        {
            foreach (var item in ObserverList)
            {
                item.Update(s);
            }
        }

    }
}
