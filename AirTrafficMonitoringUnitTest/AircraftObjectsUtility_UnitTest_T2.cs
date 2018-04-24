using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic;
using AirTrafficMonitoringLogic.AircraftUtillity;
using NSubstitute;
using NUnit.Framework;

namespace AirTrafficMonitoringUnitTest
{
    [TestFixture()]
    class AircraftObjectsUtility_UnitTest_T2
    {

        private AircraftObjectsUtility _uut;
        private List<String> stringAircraft;
        private string[] correctArray;
        private Aircraft _testAircraft;

        [SetUp]
        public void SetUp()
        {
            _uut = new AircraftObjectsUtility();
            stringAircraft = new List<string> {"ATR423;39045;12932;14000;20151006213456789"};
            correctArray = new string[] { "ATR423", "39045", "12932", "14000", "20151006213456789" };
            _testAircraft = _uut.ArrayToAircraftObject(correctArray);
        }


        [Test]
        public void splitToArray_correctly_split_stringarray()
        {
            string[] localarray = new string[5];
            for (int i = 0; i < stringAircraft.Count; i++)
            {
                localarray = _uut.SplitToArray(stringAircraft,i);
            }
            Assert.AreEqual(localarray, correctArray);
            
        }

        [Test]
        public void ArraytoAircraftObject_creates_Aircraft_object()
        {
            Aircraft ac = new Aircraft("ATR423",Int32.Parse("39045"),Int32.Parse("12932"),Int32.Parse("14000"), DateTime.ParseExact("20151006213456789", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            Assert.That(_uut.ArrayToAircraftObject(correctArray).GetType() == ac.GetType());
        }

        [Test]
        public void getListofAircraftObjects_return_listofAircrafts()
        {
            Aircraft ac = new Aircraft("ATR423", Int32.Parse("39045"), Int32.Parse("12932"), Int32.Parse("14000"), DateTime.ParseExact("20151006213456789", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            List<Aircraft> lac = new List<Aircraft>();
            lac.Add(ac);
            
            var local = _uut.getListofAircraftObjects(stringAircraft);
            Assert.AreEqual(lac[0]._tag,local[0]._tag);
            
        }
        [Test]
        public void ReciveAirCrafts_UpdateTransponderData_TestOfTag()
        {
            Assert.That(_testAircraft._tag, Is.EqualTo("ATR423"));

        }
        [Test]
        public void ReciveAirCrafts_UpdateTransponderData_TestOfX()
        {
            Assert.That(_testAircraft._xcoordinate, Is.EqualTo(39045));

        }
        [Test]
        public void ReciveAirCrafts_UpdateTransponderData_TestOfY()
        {
            Assert.That(_testAircraft._ycoordinate, Is.EqualTo(12932));
        }
        [Test]
        public void ReciveAirCrafts_UpdateTransponderData_TestOfAltitude()
        {
            Assert.That(_testAircraft._altitude, Is.EqualTo(14000));
        }
        [Test]
        public void ReciveAirCrafts_UpdateTransponderData_TimestampYearIsCorrect()
        {
            
            Assert.That(_testAircraft._timestamp.Year, Is.EqualTo(2015));
        }

        [Test]
        public void ReciveAirCrafts_UpdateTransponderData_TimestampMonthIsCorrect()
        {
            Assert.That(_testAircraft._timestamp.Month, Is.EqualTo(10));
        }


        [Test]
        public void ReciveAirCrafts_UpdateTransponderData_TimestampDayIsCorrect()
        {
            Assert.That(_testAircraft._timestamp.Day, Is.EqualTo(06));
        }
        [Test]
        public void ReciveAirCrafts_UpdateTransponderData_TimestampHourIsCorrect()
        {
            Assert.That(_testAircraft._timestamp.Hour, Is.EqualTo(21));
        }
        [Test]
        public void ReciveAirCrafts_UpdateTransponderData_TimestampMinuteIsCorrect()
        {
            Assert.That(_testAircraft._timestamp.Minute, Is.EqualTo(34));
        }
        [Test]
        public void ReciveAirCrafts_UpdateTransponderData_TimestampSecondIsCorrect()
        {
            Assert.That(_testAircraft._timestamp.Second, Is.EqualTo(56));
        }
        [Test]
        public void ReciveAirCrafts_UpdateTransponderData_TimestampMSIsCorrect()
        {
            Assert.That(_testAircraft._timestamp.Millisecond, Is.EqualTo(789));
        }
        [Test]
        public void ReciveAirCrafts_UpdateTransponderData_Velocity()
        {
            Assert.That(_testAircraft.Velocity, Is.EqualTo(0));
        }

        [Test]
        public void ReciveAirCrafts_UpdateTransponderData_Course()
        {
            Assert.That(_testAircraft.Course, Is.EqualTo(0));
        }

        [Test]
        public void TestOfToStringMethod()
        {
            Assert.That(_testAircraft.ToString(), Is.EqualTo("Tag name is: ATR423 Current position is: 39045,12932 m, Current Altitude is: 14000 m, Current velocity is: 0 m/s, Current compass course: 0"));
        }
    }
}
