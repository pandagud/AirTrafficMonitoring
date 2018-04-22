using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoringLogic
{
    public class SeparationEventToFileLog
    {
        


        string testOfSepEventStringToFile = "This is a doc showing all the different separation events occuring in our Air Traffic Monitoring system: ";
        private string[] test2 = {"tag1", "tag2", "time"};
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public SeparationEventToFileLog()
        {
           File.WriteAllText(path + @"\SeparationEvents.txt", testOfSepEventStringToFile);
        }

        public void writeToFile()
        {
            File.AppendAllLines(path + @"\SeparationEvents.txt", test2);
        }


        //få en til at lytte på events. læg dem i en liste - hvis eventet stopper med at komme - fjern det fra listen
        //udskriv til fil - hvor mange gange?

    }
}
