using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;
using NSubstitute;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic;
using AirTrafficMonitoringLogic.AircraftUtillity;
using AirTrafficMonitoringLogic.Interface;

namespace AirTrafficMonitoringUnitTest
{
    [TestFixture]
    public class HandleSeparationEvents_Unittest_T7
    {
        IToLogFile _itToLogFile = Substitute.For<IToLogFile>();
        ISeparationEvent _iseSeparationEvent = Substitute.For<ISeparationEvent>();
        private List<SeparationEventArgs> SeList = new List<SeparationEventArgs>();
        private SeparationEventArgs se1;
        private SeparationEventArgs se2;
        private SeparationEventArgs se3;
        private HandleSeparationEvents _uut;
        [SetUp]
        public void SetUp()
        {
            se1 = new SeparationEventArgs(DateTime.Now, "testflight1", "testflight2");
            se2 = new SeparationEventArgs(DateTime.Now, "testflight3", "testflight4");
            se3 = new SeparationEventArgs(DateTime.Now, "testflight4", "testflight5");
            _uut = new HandleSeparationEvents(_iseSeparationEvent, _itToLogFile);
            SeList.Add(se1);
            SeList.Add(se2);
            _uut.Update(SeList);

        }

        [Test]
        public void HandleEvents_NewEventRecieved()
        {
            Assert.AreEqual(_uut.listOfCurrentSeparationEvents,SeList);
        }
        [Test]
        public void HandleEvents_CheckForNewEvent()
        {
            se3 = new SeparationEventArgs(DateTime.Now, "testflight4", "testflight5");
            SeList.Add(se3);
            _uut.Update(SeList);
            Assert.AreEqual(_uut.listOfCurrentSeparationEvents,SeList);
        }



        [Test]
        public void HandleEvents_UpdatingExistingEvent()
        {
            se3 = new SeparationEventArgs(DateTime.Now.AddMinutes(5), "testflight4", "testflight5");
            SeList.Add(se3);
            _uut.Update(SeList);
            Assert.AreEqual(_uut.listOfCurrentSeparationEvents[2],se3);
        }

        [Test]
        public void CheckforDeactivatedEvents()
        {
            SeList.RemoveAt(1);
            _uut.Update(SeList);
            Assert.AreEqual(SeList,_uut.listOfCurrentSeparationEvents);

        }




    }
}
