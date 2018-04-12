using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic.Interface;

namespace AirTrafficMonitoringLogic
{
    public class MonitoringAirSpace
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
                if (i._xcoordinate < 10000 && i._ycoordinate < 90000 && 500 < i._altitude && i._altitude < 20000)
                {
                    localList.Add(i);
                }
            }
            
        }

       


    }
}
