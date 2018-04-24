using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic.AircraftUtillity;
using AirTrafficMonitoringLogic.Interface;
using AirTrafficMonitoringLogic.Utillity;

namespace AirTrafficMonitoringLogic
{
    
    
    public class CreateSeparationEvents : SubjectObserverSepArgs,IObserver, ISeparationEvent
    {
        public List<SeparationEventArgs> listOfCurrentSeparationEvents;
        
        

       // public event SeparationEventHandler separationEvent;
        public void Update(List<Aircraft> s)
        {
            listOfCurrentSeparationEvents = new List<SeparationEventArgs>();
            List<Aircraft> _tempList = new List<Aircraft>(s);

            for (int i = 0; i < s.Count-1; i++)
            {
                if (checkAltitude(s[i+1], _tempList[i]) == true && checkHorizontalSeparation(s[i+1], _tempList[i]) == true && s[i+1]._tag != _tempList[i]._tag)
                {
                    SeparationEventArgs _se = new SeparationEventArgs(s[i+1]._timestamp,s[i+1]._tag,_tempList[i]._tag);
                    listOfCurrentSeparationEvents.Add(_se);
                }
            }
            Notify(listOfCurrentSeparationEvents);
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
