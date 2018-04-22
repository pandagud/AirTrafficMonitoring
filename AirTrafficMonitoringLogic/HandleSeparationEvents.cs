using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic.AircraftUtillity;

namespace AirTrafficMonitoringLogic
{
    public class HandleSeparationEvents
    {
        private SeparationEventToFileLog toFileLog = new SeparationEventToFileLog();
        public List<SeparationEventArgs> listOfCurrentSeparationEvents;
        public HandleSeparationEvents(CreateSeparationEvents cse)
        {
            listOfCurrentSeparationEvents = new List<SeparationEventArgs>();
            cse.separationEvent += HandleEvents;
            
        }

        public void HandleEvents(object sender, SeparationEventArgs se)
        { // tilføj til liste af eventArgs, hvis det ikke er på listen i forvejen, hvis det ikke er på listen i forvejen udskrives det.
            //lav noget der viser de events der ligger i listen på console
            if (listOfCurrentSeparationEvents.Any(se.getTags()) ) ;
            //If løkke der løber igennem listen og ser om se findes i den i forvejen - med de to tags, 

        }

        public void writeNewEventsToLog(SeparationEventArgs se)
        {
            toFileLog.writeToFile(se.getTags(), se.getTime().ToString());
        }

        
        
    }
}
