using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic;
using AirTrafficMonitoringLogic.Interface;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;

namespace AirTrafficMonitoringIntegrationTest
{
    [TestFixture]
    class IT2_RecieveAircraftsToDirectionAndSpeedCalculator
    {

        private IRecieveAircrafts _iRecieveAircrafts;
        private ICourseAndVelocityCalculator _iCourseAndVelocityCalculator;
        private ITransponderReceiver _iTransponderReceiver;
        private IAirCraftObjectsUtility _iAirCraftObjectsUtility;

        [SetUp]
        public void SetUp()
        {
            _iTransponderReceiver = Substitute.For<ITransponderReceiver>();
            _iAirCraftObjectsUtility = Substitute.For<IAirCraftObjectsUtility>();
            _iRecieveAircrafts = new RecieveAircrafts(_iTransponderReceiver,_iAirCraftObjectsUtility);
            _iCourseAndVelocityCalculator = Substitute.For<ICourseAndVelocityCalculator>();
        }


        #region RecieveAircraftsToDirectionAndSpeedCalculator

        [Test]
        public void Test1()
        {

        }


        #endregion





    }
}
