using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoringLogic.AircraftUtillity
{
    public class DirectionAndSpeedCalculator
    {
        public List<Aircraft> OldList;
        public List<Aircraft> CurrentList;
        

        public DirectionAndSpeedCalculator()
        {
            OldList = new List<Aircraft>();
            CurrentList = new List<Aircraft>();
           
        }

        public List<Aircraft> CalculatBoth(List<Aircraft> newList)
        {
            
            CurrentList = newList;
            
            if (OldList.Count != 0)
            {
                List<Aircraft> local = new List<Aircraft>();
                local = newList;
                local = SortAircraftList(local);
                CalculatSpeed(local);
                
            }
            
            OldList = newList;
            return CurrentList;

        }

        public List<Aircraft> CalculatDirection(List<Aircraft> newlist)
        {
            return newlist;
        }

        public List<Aircraft> CalculatSpeed(List<Aircraft> newlist)
        {
            for (int i = 0; i < newlist.Count; i++)
            {
                var xDist = Math.Sqrt(Math.Pow(newlist[i]._xcoordinate - OldList[i]._xcoordinate, 2));
                var yDist = Math.Sqrt(Math.Pow(newlist[i]._ycoordinate - OldList[i]._ycoordinate, 2));
                var altDist = Math.Sqrt(Math.Pow(newlist[i]._altitude - OldList[i]._altitude, 2));
                TimeSpan timeSpan = newlist[i]._timestamp - OldList[i]._timestamp;
                var timeDiff = (timeSpan.TotalMilliseconds) / 1000;
                var velocity = 0;


                velocity = Convert.ToInt32(
                    ((Math.Sqrt(Math.Pow(xDist, 2) + Math.Pow(yDist, 2) + Math.Pow(altDist, 2))) / timeDiff));
                newlist[i].Velocity = velocity;
            }

            return newlist;
        }

        public List<Aircraft> SortAircraftList(List<Aircraft> sortList)
        {
            sortList.OrderBy(Aircraft => Aircraft._tag);
            OldList.OrderBy(Aircraft => Aircraft._tag);


            for (int i = 0; i < sortList.Count; i++)
            {
                try
                {
                    if (sortList[i]._tag == OldList[i]._tag)
                    {

                    }
                }
                catch (Exception e)
                {
                    if (sortList.Count > OldList.Count)
                        sortList.RemoveAt(i);
                    else if (OldList.Count > sortList.Count)
                    {
                        OldList.RemoveAt(i);
                    }
                    i--;                   
                }
            }
            return sortList;
        }
    }
    
}
