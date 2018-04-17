using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoringLogic.AircraftUtillity
{
    public class DirectionAndSpeedCalculator
    {
        public List<Aircraft> savedList;
        private int firstTime = 0;

        public DirectionAndSpeedCalculator()
        {
            savedList =new List<Aircraft>();
        }
        public List<Aircraft> CalculatBoth(List<Aircraft> newList)
        {
            
            if (firstTime != 0)
            {
                SortAircraftList(newList);
                CalculatSpeed(newList);
                return savedList;
            }
            else
            {
                firstTime++;
                savedList = newList;
                return savedList;
            }
        }

        public List<Aircraft> CalculatDirection(List<Aircraft> newlist)
        {
            return newlist;
        }
        public List<Aircraft> CalculatSpeed(List<Aircraft> newlist)
        {
            for (int i = 0; i < newlist.Count; i++)
            {
                var xDist = Math.Sqrt(Math.Pow(newlist[i]._xcoordinate - savedList[i]._xcoordinate, 2));
                var yDist = Math.Sqrt(Math.Pow(newlist[i]._ycoordinate - savedList[i]._ycoordinate, 2));
                var altDist = Math.Sqrt(Math.Pow(newlist[i]._altitude - savedList[i]._altitude, 2));
               // TimeSpan timeSpan = track.TimeStamp - oldTrack.TimeStamp;
               // var timeDiff = (timeSpan.TotalMilliseconds) / 1000;
               // var velocity = 0;


               // velocity = Convert.ToInt32(((Math.Sqrt(Math.Pow(xDist, 2) + Math.Pow(yDist, 2) + Math.Pow(altDist, 2))) / timeDiff));
            }
            return newlist;
        }

        public List<Aircraft> SortAircraftList(List<Aircraft> newlist)
        {
            newlist.Sort();
            savedList.Sort();
            
            for (int i = 0; i < newlist.Count; i++)
            {
                if (newlist[i]._tag == savedList[i]._tag)
                {

                }
                else
                {
                    if (newlist.Count > savedList.Count)
                        newlist.RemoveAt(i);
                    else if(savedList.Count>newlist.Count)
                    {
                        savedList.RemoveAt(i);
                    }
                }
            }

            return newlist;
        }

    }
}
