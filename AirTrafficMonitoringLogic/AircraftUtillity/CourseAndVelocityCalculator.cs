using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic.Interface;

namespace AirTrafficMonitoringLogic.AircraftUtillity
{
    public class CourseAndVelocityCalculator: ICourseAndVelocityCalculator
    {
        public List<Aircraft> OldList;
        public List<Aircraft> CurrentList;
        

        public CourseAndVelocityCalculator()
        {
            OldList = new List<Aircraft>();
            CurrentList = new List<Aircraft>();
        }

        public List<Aircraft> CalculateBoth(List<Aircraft> newList)
        {
            CurrentList = newList;
            
            if (OldList.Count != 0 && OldList != newList)
            {
                List<Aircraft> local = new List<Aircraft>(newList);
                local = SortAircraftList(local);
                CalculateSpeed(local);
                CalculateDirection(local);
            }
            OldList = newList;
            return CurrentList;

        }

        public List<Aircraft> CalculateDirection(List<Aircraft> newlist)
        {
            for (int i = 0; i < newlist.Count; i++)
            {
                var xDist = newlist[i]._xcoordinate - OldList[i]._xcoordinate;
                var yDist = newlist[i]._ycoordinate - OldList[i]._ycoordinate;
                var CourseRad = Math.Atan2(yDist, xDist);
                var CourseDeg = Math.Round(CourseRad * (180 / Math.PI),1);
                newlist[i].Course = CourseDeg;
            }
            return newlist;
        }

      

        public List<Aircraft> CalculateSpeed(List<Aircraft> newlist)
        {
            for (int i = 0; i < newlist.Count; i++)
            {
                var xDist = Math.Sqrt(Math.Pow(newlist[i]._xcoordinate - OldList[i]._xcoordinate, 2));
                var yDist = Math.Sqrt(Math.Pow(newlist[i]._ycoordinate - OldList[i]._ycoordinate, 2));
                var altDist = Math.Sqrt(Math.Pow(newlist[i]._altitude - OldList[i]._altitude, 2));
                TimeSpan timeSpan = newlist[i]._timestamp - OldList[i]._timestamp;
                var timeDiff = (timeSpan.TotalMilliseconds) / 1000;
                try
                {
                    var velocity = Math.Abs(Convert.ToInt32(
                        ((Math.Sqrt(Math.Pow(xDist, 2) + Math.Pow(yDist, 2) + Math.Pow(altDist, 2))) / timeDiff)));
                    newlist[i].Velocity = velocity;
                }
                catch (Exception e)
                {
                    newlist[i].Velocity = 0;
                }

                    
                
                
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
