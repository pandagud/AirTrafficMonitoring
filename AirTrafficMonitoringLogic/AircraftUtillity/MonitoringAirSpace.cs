using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic.Interface;
using AirTrafficMonitoringLogic.Utillity;

namespace AirTrafficMonitoringLogic
{
    public class MonitoringAirSpace:SubjectObserver,IMonitoringAirSpace
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
            if(data._xcoordinate >= 10000 && data._xcoordinate <= 90000)
                if (data._ycoordinate >= 10000 && data._ycoordinate <= 90000)
                {
                    return true;
                }

            return false;
        }
        public bool checkForAltitude(Aircraft data)
        {
            if (data._altitude >= 500 && data._altitude <= 20000)
            {
                return true;
            }

            return false;
        }




    }
}
