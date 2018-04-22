using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic.AircraftUtillity;
using AirTrafficMonitoringLogic.Interface;

namespace AirTrafficMonitoringLogic
{
    public delegate void SeparationEventHandler(object sender, SeparationEventArgs se);
    public class CreateSeparationEvents : IObserver
    {
        

        private event SeparationEventHandler separationEvent;
        

        public void Update(List<Aircraft> s)
        {
            List<Aircraft> _tempList = new List<Aircraft>(s);

            for (int i = 0; i < s.Count; i++)
            {
                if (checkAltitude(s[i], _tempList[0]) == true && checkHorizontalSeparation(s[i], _tempList[0]) == true)
                {
                    SeparationEventArgs _se = new SeparationEventArgs(s[i]._timestamp,s[i]._tag,_tempList[0]._tag);
                    onSeparationEvent(_se);
                }

                _tempList.RemoveAt(0);
            }
        }

        protected virtual void onSeparationEvent(SeparationEventArgs se)
        {
            SeparationEventHandler handler = separationEvent;
            if (se != null)
            {
                handler(this, se);
            }
        }

        public bool checkAltitude(Aircraft s, Aircraft s1)
        {
            if (Math.Abs(s._altitude - s1._altitude) <= 300)
            {
                return true;
            }
            else return false;
        }

        public bool checkHorizontalSeparation(Aircraft s, Aircraft s1)
        {
            double x = Math.Pow(Math.Abs(s._xcoordinate - s1._xcoordinate), 2);
            double y = Math.Pow(Math.Abs(s._ycoordinate - s1._ycoordinate), 2);

            if (Math.Sqrt(x + y) <= 5000)
            {
                return true;
            }
            else return false;
        }
    }
}
