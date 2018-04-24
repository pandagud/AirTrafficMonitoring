using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoringLogic.Interface
{
   public interface ICourseAndVelocityCalculator
   {
       List<Aircraft> CalculateBoth(List<Aircraft> newList);
       List<Aircraft> CalculateDirection(List<Aircraft> newlist);

       List<Aircraft> CalculatSpeed(List<Aircraft> newlist);

       List<Aircraft> SortAircraftList(List<Aircraft> sortList);


   }
}
