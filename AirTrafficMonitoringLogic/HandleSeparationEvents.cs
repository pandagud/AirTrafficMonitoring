using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic.AircraftUtillity;
using AirTrafficMonitoringLogic.Interface;

namespace AirTrafficMonitoringLogic
{
    public class HandleSeparationEvents:IHandleSeparationEvents
    {
        
        public List<SeparationEventArgs> listOfCurrentSeparationEvents;
        private IToLogFile _itlFile;
        public HandleSeparationEvents(ISeprationsEvent cse, IToLogFile itlFile)
        {
            listOfCurrentSeparationEvents = new List<SeparationEventArgs>();
            cse.SeprationsEvent += HandleEvents;
            _itlFile = itlFile;

        }

        public void HandleEvents(object sender, SeparationEventArgs se)
        { // tilføj til liste af eventArgs, hvis det ikke er på listen i forvejen, hvis det ikke er på listen i forvejen udskrives det.
            //lav noget der viser de events der ligger i listen på console
            //if (listOfCurrentSeparationEvents.Exists(se.getTags()) == true ) ;
            //If løkke der løber igennem listen og ser om se findes i den i forvejen - med de to tags,
            bool boaksd = false;
            for (int i = 0; i < listOfCurrentSeparationEvents.Count; i++)
            {
                if (listOfCurrentSeparationEvents[i].getTags() == se.getTags())
                {
                    boaksd = true;
                    listOfCurrentSeparationEvents[i] = se;
                }
            }

            if (boaksd == false)
            {
                listOfCurrentSeparationEvents.Add(se);
                writeNewEventsToLog(se);
            }
            updateConsole();
            checkForDeactivatedEvents(se);
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

        public void checkForDeactivatedEvents(SeparationEventArgs se)
        {
            for (int i = 0; i < listOfCurrentSeparationEvents.Count; i++)
            {
                if (listOfCurrentSeparationEvents[i].getTime().AddSeconds(5) < DateTime.Now )
                {
                    _itlFile.writeDoneEventToFile(listOfCurrentSeparationEvents[i].getTags(),listOfCurrentSeparationEvents[i].getTime().ToString());
                    listOfCurrentSeparationEvents.RemoveAt(i);
                    
                }
                
            }
        }



    }
}
