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

        private IRecieveAircrafts _iRecieveAircrafts;
        private ICourseAndVelocityCalculator _iCourseAndVelocityCalculator;
        private ITransponderReceiver _iTransponderReceiver;
        private IAirCraftObjectsUtility _iAirCraftObjectsUtility;

        private List<string> _list;
        private List<Aircraft> _aircraftlist;
        private int _nEventsReceived;

        [SetUp]
        public void SetUp()
        {
            _iTransponderReceiver = Substitute.For<ITransponderReceiver>();
            _iAirCraftObjectsUtility = new AircraftObjectsUtility();
            _iCourseAndVelocityCalculator = new CourseAndVelocityCalculator();
            _iRecieveAircrafts = Substitute.For<IRecieveAircrafts>(_iTransponderReceiver, _iAirCraftObjectsUtility, _iCourseAndVelocityCalculator);
            //_iRecieveAircrafts = new RecieveAircrafts(_iTransponderReceiver, _iAirCraftObjectsUtility, _iCourseAndVelocityCalculator);

            _aircraftlist = new List<Aircraft>();
            _list = new List<string>();
            _nEventsReceived = 0;

            _iRecieveAircrafts.TransponderDataObjectReady += (args) =>
            {
                _aircraftlist = _iAirCraftObjectsUtility.getListofAircraftObjects(_list);
                _nEventsReceived++;
            };
        }

        #region RecieveAircraftsToDirectionAndSpeedCalculator

        [Test]
        public void UpdateTransponderData_With_CourseAndVelocity()
        {


        }


        #endregion





    }
}
