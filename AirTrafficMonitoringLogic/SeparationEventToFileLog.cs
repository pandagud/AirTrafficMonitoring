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
        private string test = "tag1, tag2 and time of occurence";
        private string HeaderOfFile = "This txt file contains all the raised separation events";
        private string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public SeparationEventToFileLog()
        {
            File.WriteAllText(path + @"SeparationEvents.txt", HeaderOfFile);
        }

        public void writeToFile() // indsæt i header den string der skal udskrives og sæt den ind i stedet for test.
        {
            File.AppendAllText(path + @"SeparationEvents.txt", test);
        }

    }
}
