using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic;
using AirTrafficMonitoringLogic.AircraftUtillity;
using AirTrafficMonitoringLogic.Interface;
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
        private DateTime _date;

        [SetUp]
        public void SetUp()
        {
            AircraftList = new List<Aircraft>();
            AircraftList = new List<Aircraft>();
            _testAircraft1 = new Aircraft("ATR423", 0, 0, 20000, DateTime.ParseExact("20151006213456789", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            _testAircraft2 = new Aircraft("ATR424", 0, 5000, 20000, DateTime.ParseExact("20151006213456789", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            _testAircraft3 = new Aircraft("ATR425", 0, 5001, 19700, DateTime.ParseExact("20151006213456789", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            _testAircraft4 = new Aircraft("ATR426", 58000, 23000, 14000, DateTime.ParseExact("20151006213456789", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            _testAircraft5 = new Aircraft("ATR427", 45000, 30000, 15000, DateTime.ParseExact("20151006213456789", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));


            AircraftList.Add(_testAircraft1);
            AircraftList.Add(_testAircraft2);
            
            List<Aircraft>_aircraftlist = new List<Aircraft>();
                
                
            _uut = new CreateSeparationEvents();
            

        }
        //public class TestClass : IObserverSepArgs
        //{
        //    List<SeparationEventArgs> testList 
        //    public void Update(List<SeparationEventArgs> s)
        //    {
                
        //    }
        //}

        [Test]
        public void Update_CheckListForSepEvents()
        {

        }

        [Test]
        public void Update_CheckSeparationEventArgsTags()
        {
            _uut.Update(AircraftList);

            Assert.AreEqual("ATR424 ATR423", _uut.listOfCurrentSeparationEvents[0].getTags());
        }
        [Test]
        public void Update_CheckSeparationEventArgsDate()
        {
            _uut.Update(AircraftList);
            DateTime obj = DateTime.Parse("2015-10-06 21:34:56.789");
            Assert.AreEqual(obj, _uut.listOfCurrentSeparationEvents[0].getTime());
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
        public void CreateSeparationEvents_CheckHorizontalSeparation_onBoundary_5000_true()
        {
            Assert.AreEqual(true, _uut.checkHorizontalSeparation(_testAircraft1, _testAircraft2));
        }

        [Test]
        public void CreateSeparationEvents_CheckHorizontalSeparation_onBoundary_5001_false()
        {
            Assert.AreEqual(false, _uut.checkHorizontalSeparation(_testAircraft1, _testAircraft3));
        }
    }
}
