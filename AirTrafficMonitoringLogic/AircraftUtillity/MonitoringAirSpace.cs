using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic.Interface;
using AirTrafficMonitoringLogic.Utillity;

namespace AirTrafficMonitoringLogic
{
    public class MonitoringAirSpace:SubjectObserver,IMonotoringAirSpapce
    {
        private List<Aircraft> localList;
        public MonitoringAirSpace(IRecieveAircrafts _recieveAircrafts)
        {
            _recieveAircrafts.TransponderDataObjectReady += Monitor;
            
            
        }

        public void Monitor(List<Aircraft> data)
        {
            localList= new List<Aircraft>();
            foreach (var i in data)
            {
                if (checkForXAndY(i)&&checkForAltitude(i))
                {
                    localList.Add(i);
                }
            }
            Notify(localList);
            
        }

        public bool checkForXAndY(Aircraft data)
        {
            if(Enumerable.Range(9999,90001).Contains(data._xcoordinate)&& Enumerable.Range(9999, 90001).Contains(data._ycoordinate))
            {
                return true;
            }

            return false;
        }
        public bool checkForAltitude(Aircraft data)
        {
            if (Enumerable.Range(499, 20001).Contains(data._altitude))
            {
                return true;
            }

            return false;
        }




    }
}
