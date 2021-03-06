﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic;
using AirTrafficMonitoringLogic.AircraftUtillity;
using AirTrafficMonitoringLogic.Interface;
using AirTrafficMonitoringLogic.Utillity;
using NUnit.Framework;
using NSubstitute;
using TransponderReceiver;

namespace AirTrafficMonitoringIntegrationTest
{
    [TestFixture]
    public class IT3_MonitoringToRecieveAircrafts
    {
        private IAirCraftObjectsUtility _airCraftObjectsUtility;
        private RecieveAircrafts _recieveAircrafts;
        private MonitoringAirSpace _monitoringAirSpace;
        private ICourseAndVelocityCalculator _courseAndVelocityCalculator;
        private IObserver _iobs;
        private ITransponderReceiver _receiver;
        private IObserver _sepEvent;
        private int _nEventsReceived;
        private int _mEvnetsReceived;
        private List<string> _list;
        private List<Aircraft> _aircraftlist;

        
        private List<Aircraft> _testlist;
        private Aircraft _aircraft1;
        private Aircraft _aircraft2;

        [SetUp]
        public void Setup()
        {
            _courseAndVelocityCalculator = new CourseAndVelocityCalculator();
            _airCraftObjectsUtility = new AircraftObjectsUtility();
            _receiver = Substitute.For<ITransponderReceiver>();
            _recieveAircrafts = new RecieveAircrafts(_receiver, _airCraftObjectsUtility, _courseAndVelocityCalculator);
            _monitoringAirSpace= new MonitoringAirSpace(_recieveAircrafts);
            _sepEvent = Substitute.For<CreateSeparationEvents>();
            _monitoringAirSpace.Attach(_sepEvent);
            
            _testlist = new List<Aircraft>();
            _aircraft1 = new Aircraft("VBF451",67000,28912,7300, DateTime.ParseExact("20180408143814504", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            _aircraft2 = new Aircraft("VBF767", 67000, 28912, 7300, DateTime.ParseExact("20180408143814504", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            _testlist.Add(_aircraft1);
            _testlist.Add(_aircraft2);

        }

        [Test]
        public void MonitoringAirSpace_Test_of_Monitor_Iscalled()
        {
            var args = new RawTransponderDataEventArgs(new List<string> { "VBF451;67000;28912;7300;20180408143814504" });
            var args1 = new RawTransponderDataEventArgs(new List<string> { "VBF767;67000;28912;7300;20180408143814504" });
            _recieveAircrafts.UpdateTransponderData(args);
            _recieveAircrafts.UpdateTransponderData(args1);
            _sepEvent.Received().Update(_testlist);
            
        }
 
    }
}
