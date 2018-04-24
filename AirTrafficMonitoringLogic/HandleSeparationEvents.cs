using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic.AircraftUtillity;
using AirTrafficMonitoringLogic.Interface;

namespace AirTrafficMonitoringLogic
{
    public class HandleSeparationEvents:IHandleSeparationEvents, IObserverSepArgs
    {
        
        public List<SeparationEventArgs> listOfCurrentSeparationEvents;
        public List<SeparationEventArgs> listOfOldSeparationEvents;
        private IToLogFile _itlFile;
        public HandleSeparationEvents(ISeparationEvent cse, IToLogFile itlFile)
        {
            listOfCurrentSeparationEvents = new List<SeparationEventArgs>();
            listOfOldSeparationEvents = new List<SeparationEventArgs>();
            _itlFile = itlFile;

        }

        public void writeNewEventsToLog(SeparationEventArgs se)
        {
            _itlFile.writeNewEventToFile(se.getTags(), se.getTime().ToString());
        }

        public void updateConsole()
        {
            for (int i = 0; i < listOfCurrentSeparationEvents.Count; i++)
            {
                //Console.Clear();
                Console.WriteLine(listOfCurrentSeparationEvents[i].ToString());
            }
        }

        public void checkForDeactivatedEvents(List<SeparationEventArgs> s)
        {
            foreach (var t in listOfOldSeparationEvents)
            {
                bool b = false;
                foreach (var t1 in listOfCurrentSeparationEvents)
                {
                    if (t.getTags() == t1.getTags())
                    {
                        b = true;
                    }
                }

                if (b = false)
                {
                    _itlFile.writeDoneEventToFile(t.getTags(), t.getTime().ToString()); 
                }
            }
        }

        public void checkForNewEvents(List<SeparationEventArgs> s)
        {
            foreach (var t in listOfCurrentSeparationEvents)
            {
                bool b = false;
                foreach (var t1 in listOfOldSeparationEvents)
                {
                    if (t.getTags() == t1.getTags())
                    {
                        b = true;
                    }
                }

                if (b = false)
                {
                    _itlFile.writeNewEventToFile(t.getTags(), t.getTime().ToString());
                }
            }
        }

        public void Update(List<SeparationEventArgs> s)
        {
            if (listOfOldSeparationEvents.Count == 0)
            {
                listOfOldSeparationEvents = new List<SeparationEventArgs>(s);
            }
            listOfCurrentSeparationEvents = new List<SeparationEventArgs>(s);

            checkForDeactivatedEvents(listOfCurrentSeparationEvents);
            checkForNewEvents(listOfCurrentSeparationEvents);
            foreach (var SepEvent in listOfCurrentSeparationEvents)
            {
                Console.WriteLine(SepEvent.ToString());
            }
        }
    }
}
