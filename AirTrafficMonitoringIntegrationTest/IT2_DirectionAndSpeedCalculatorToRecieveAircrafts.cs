using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic;
using AirTrafficMonitoringLogic.AircraftUtillity;
using AirTrafficMonitoringLogic.Interface;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;

namespace AirTrafficMonitoringIntegrationTest
{
    [TestFixture]
    class IT2_DirectionAndSpeedCalculatorToRecieveAircrafts
    {

        private RecieveAircrafts _recieveAircrafts;
        private ICourseAndVelocityCalculator _iCourseAndVelocityCalculator;
        private ITransponderReceiver _iTransponderReceiver;
        private IAirCraftObjectsUtility _iAirCraftObjectsUtility;

        [SetUp]
        public void SetUp()
        {
            _iTransponderReceiver = Substitute.For<ITransponderReceiver>();
            _iAirCraftObjectsUtility = new AircraftObjectsUtility();
            _iCourseAndVelocityCalculator = new CourseAndVelocityCalculator();
            _recieveAircrafts = new RecieveAircrafts(_iTransponderReceiver, _iAirCraftObjectsUtility, _iCourseAndVelocityCalculator);
        }

        #region RecieveAircraftsToDirectionAndSpeedCalculator

        [Test]
        public void UpdateTransponderData_With_Velocity()
        {
            var args = new RawTransponderDataEventArgs(new List<string> { "VBF451;94717;28912;7300;20180408143814504" });
            _recieveAircrafts.UpdateTransponderData(args);
            var args2 = new RawTransponderDataEventArgs(new List<string> { "VBF451;94617;28912;7300;20180408143815504" });
            _recieveAircrafts.UpdateTransponderData(args2);           
;           Assert.AreEqual(_recieveAircrafts.ListofAircraftObjects[0].Velocity,100);
        }

        public void UpdateTransponderData_With_Course()
        {
            var args = new RawTransponderDataEventArgs(new List<string> { "VBF451;94717;28912;7300;20180408143814504" });
            _recieveAircrafts.UpdateTransponderData(args);
            var args2 = new RawTransponderDataEventArgs(new List<string> { "VBF451;94617;28912;7300;20180408143815504" });
            _recieveAircrafts.UpdateTransponderData(args2);
            Assert.AreEqual(_recieveAircrafts.ListofAircraftObjects[0].Course,180);
        }

        #endregion





    }
}
