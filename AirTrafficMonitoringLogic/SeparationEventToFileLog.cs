using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic.Interface;

namespace AirTrafficMonitoringLogic
{
    public class SeparationEventToFileLog : IToLogFile
    {
        private string test = "tag1, tag2 and time of occurence";
        private string HeaderOfFile = "This txt file contains all the raised separation events";
        private string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public SeparationEventToFileLog()
        {
            File.WriteAllText(path + @"\SeparationEvents1.txt", HeaderOfFile);
        }

        public void writeNewEventToFile(string _tags, string _time) // indsæt i header den string der skal udskrives og sæt den ind i stedet for test.
        {
            string sepEventText = "The following two aircrafts have raised a separation event " + _tags + ". Time of event: " + _time;
            File.AppendAllText(path + @"\SeparationEvents1.txt", sepEventText);
        }

        public void writeDoneEventToFile(string _tags, string _time) // indsæt i header den string der skal udskrives og sæt den ind i stedet for test.
        {
            string sepEventText = "The following two aircrafts are no longer in a separation event " + _tags + ". Time of event: " + _time;
            File.AppendAllText(path + @"\SeparationEvents1.txt", sepEventText);
        }
    }
}
