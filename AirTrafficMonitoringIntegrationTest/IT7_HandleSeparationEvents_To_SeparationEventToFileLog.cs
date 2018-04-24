using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic;
using NSubstitute;
using NUnit.Framework.Internal;
using NUnit.Framework;
using System.IO;
using AirTrafficMonitoringLogic.AircraftUtillity;
using AirTrafficMonitoringLogic.Interface;

namespace AirTrafficMonitoringIntegrationTest
{
    [TestFixture]
    public class IT7_HandleSeparationEvents_To_SeparationEventToFileLog
    {
        private IPrint _print;
        private IHandleSeparationEvents _handleSeparationEvents;
        private IToLogFile _iToLogFile;
        private CreateSeparationEvents _separationEvent;

        private SeparationEventArgs _se1;
        public List<SeparationEventArgs> _listSeperationsArgs;

        [SetUp]
        public void SetUp()
        {
            _print = new Print();
            _iToLogFile = new SeparationEventToFileLog();
            _separationEvent = new CreateSeparationEvents();
            _handleSeparationEvents = new HandleSeparationEvents(_separationEvent, _iToLogFile, _print);

            _se1 = new SeparationEventArgs(DateTime.Now, "Aircraft1", "Aircraft2");
            _listSeperationsArgs = new List<SeparationEventArgs>();
            _listSeperationsArgs.Add(_se1);
        }


        [Test]
        public void ConnectToFileLog()
        {
            _handleSeparationEvents.checkForNewEvents(_listSeperationsArgs);
            // Check connect how?
        }
       

    }
}
