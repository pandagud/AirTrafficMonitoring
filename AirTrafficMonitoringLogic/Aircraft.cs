using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoringLogic
{
    public class Aircraft
    {
        public string _tag { get; set; }
        public int _xcoordinate { get; set; }
        public int _ycoordinate { get; set; }
        public int _altitude { get; set; }
        public DateTime _timestamp { get; set; }
        public int Velocity { get; set; }
        public int Course { get; set; }


        public Aircraft(string tag1, int xcoordinate1, int ycoordinate1, int altitude1, DateTime timestamp1)
        {
            _timestamp = timestamp1;
            _tag = tag1;
            _xcoordinate = xcoordinate1;
            _ycoordinate = ycoordinate1;
            _altitude = altitude1;
            Velocity = 0;
            Course = 0;
        }

        public override string ToString()
        {
            return String.Format(
                "Tag name is: {0} Current position is: {1},{2} m, Current Altitude is: {3} m, Current velocity is: {4} m/s, Current compass course: {5}",
                _tag, _xcoordinate, _ycoordinate, _altitude, Velocity, Course);
        }

    }
}