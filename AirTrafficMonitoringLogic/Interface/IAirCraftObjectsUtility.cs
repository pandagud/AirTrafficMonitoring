using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoringLogic.Interface
{
    public interface IAirCraftObjectsUtility
    {
        List<Aircraft> getListofAircraftObjects(List<string> data);
        string[] SplitToArray(List<string> data, int index);

        Aircraft ArrayToAircraftObject(string[] data);
    }
}
