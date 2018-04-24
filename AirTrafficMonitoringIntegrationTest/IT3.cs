using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic;
using AirTrafficMonitoringLogic.Interface;
using NUnit.Framework;

namespace AirTrafficMonitoringIntegrationTest
{
    [TestFixture]
    public class IT3
    {
        private IAirCraftObjectsUtility _airCraftObjectsUtility;
        private IRecieveAircrafts _recieveAircrafts;
        private IMonitoringAirSpace _monitoringAirSpace;

        [SetUp]
        public void Setup()
        {
            _airCraftObjectsUtility = Substitute.For<IAirCraftObjectsUtility>();
            _recieveAircrafts = new RecieveAircrafts();
            _monitoringAirSpace= new MonitoringAirSpace();
        }

        [Test]
        {

        }
    }
}
