using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic;
using NUnit.Framework.Internal;
using NUnit.Framework;
using AirTrafficMonitoringLogic.Interface;
using NSubstitute;

namespace AirTrafficMonitoringIntegrationTest
{
    [TestFixture]
    class IT7
    {
        private IToLogFile _iToLogFile;
        private ISeparationEvent _iSeparationEvent;
        private IHandleSeparationEvents _handleSeparationEvents;

        [SetUp]
        public void Setup()
        {
            _iToLogFile = Substitute.For<IToLogFile>();
            _iSeparationEvent = new CreateSeparationEvents();
            _handleSeparationEvents = new HandleSeparationEvents(_iSeparationEvent,_iToLogFile);
        }

        [Test]
        public void itOfHandleEvents()
        {

        }


    }
}
