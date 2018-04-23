using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoringLogic.Interface
{
    public interface IToLogFile
    {
        void writeNewEventToFile(string _tags, string _time);
        void writeDoneEventToFile(string _tags, string _time);
    }
}
