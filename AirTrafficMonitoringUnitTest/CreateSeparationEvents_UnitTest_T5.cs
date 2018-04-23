﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic;
using AirTrafficMonitoringLogic.AircraftUtillity;
using AirTrafficMonitoringLogic.Interface;
using Castle.Core.Smtp;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Microsoft.VisualBasic;


namespace AirTrafficMonitoringUnitTest
{
    [TestFixture()]
    class CreateSeparationEvents_UnitTest_T4
    {
        

        private CreateSeparationEvents _uut;
        private IHandleSeparationEvents _handleSeparationEvents;
        private List<Aircraft> AircraftList;
        private ISeparationEvent eventTest;
        private Aircraft _testAircraft1;
        private Aircraft _testAircraft2;
        private Aircraft _testAircraft3;
        private Aircraft _testAircraft4;
        private Aircraft _testAircraft5;
        private int _nEventsReceived;
        private int _mEventsReceived;
        
        string _sum;

        [SetUp]
        public void SetUp()
        {
            AircraftList = new List<Aircraft>();
            _handleSeparationEvents = Substitute.For<IHandleSeparationEvents>();
            eventTest = Substitute.For<ISeparationEvent>();
            AircraftList = new List<Aircraft>();
            _testAircraft1 = new Aircraft("ATR423", 10000, 10000, 20000, DateTime.ParseExact("20151006213456789", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            _testAircraft2 = new Aircraft("ATR424", 10000, 10500, 20000, DateTime.ParseExact("20151006213456789", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            _testAircraft3 = new Aircraft("ATR425", 60000, 68738, 19700, DateTime.ParseExact("20151006213456789", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            _testAircraft4 = new Aircraft("ATR426", 58000, 23000, 14000, DateTime.ParseExact("20151006213456789", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            _testAircraft5 = new Aircraft("ATR427", 45000, 30000, 15000, DateTime.ParseExact("20151006213456789", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));


            AircraftList.Add(_testAircraft1);
            AircraftList.Add(_testAircraft2);
            
            _nEventsReceived = 0;
            List<Aircraft>_aircraftlist = new List<Aircraft>();
               _nEventsReceived = 0;
            _mEventsReceived = 0;
                
                
            _uut = new CreateSeparationEvents();
     

            _uut.SeprationsEvent += (o, args) =>
            {
                _sum = args.getTags();
 
                _aircraftlist = AircraftList;
                _nEventsReceived++;
            };

         
            
        }

        [Test]
        public void Update_with_separationEvent_Tags()
        {
            _uut.Update(AircraftList);

            Assert.AreEqual("ATR424 ATR423", _sum);
        }

        [Test]
        public void Update_with_separationEvent_CheckIfEventIsCreated()
        {
            _uut.Update(AircraftList);

            Assert.AreEqual(1, _nEventsReceived);
        }
       
        [Test]
        public void CreateSeparationEvents_CheckAltitude_onBoundary_300()
        {
            Assert.AreEqual(true, _uut.checkAltitude(_testAircraft1, _testAircraft3));
        }
        [Test]
        public void CreateSeparationEvents_CheckAltitude_onBoundary_0()
        {
            Assert.AreEqual(true, _uut.checkAltitude(_testAircraft1, _testAircraft2));
        }
        [Test]
        public void CreateSeparationEvents_CheckAltitude_Over_300()
        {
            Assert.AreEqual(false, _uut.checkAltitude(_testAircraft1, _testAircraft4));
        }
        
        [Test]
        public void CreateSeparationEvents_CheckHorizontalSeparation_true()
        {
            Assert.AreEqual(true, _uut.checkHorizontalSeparation(_testAircraft1, _testAircraft2));
        }

        [Test]
        public void CreateSeparationEvents_CheckHorizontalSeparation_false()
        {
            Assert.AreEqual(false, _uut.checkHorizontalSeparation(_testAircraft1, _testAircraft3));
        }

        [Test]
        public void CreateSeparationEvents_onSeparationEvent()
        {
            
          
            //var args = new RawTransponderDataEventArgs(new List<string> { "VBF451;94717;28912;7300;20180408143814504" });
            //_receiver.TransponderDataReady += Raise.EventWith(args);
            //Assert.AreEqual(_list[0], "VBF451;94717;28912;7300;20180408143814504");
        }
    }
}
