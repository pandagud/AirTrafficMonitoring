using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic;
using NSubstitute;
using NUnit.Framework;

namespace AirTrafficMonitoringUnitTest
{
    [TestFixture()]
    class AircraftObjectsUtility_UnitTest_T3
    {

        private AircraftObjectsUtility _uut;
        private List<String> stringAircraft;
        private string[] correctArray;
        
        [SetUp]
        public void SetUp()
        {
            _uut = new AircraftObjectsUtility();
            stringAircraft = new List<string> {"ATR423;39045;12932;14000;20151006213456789"};
            correctArray = new string[] { "ATR423", "39045", "12932", "14000", "20151006213456789" };
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
            Aircraft ac = new Aircraft("ATR423",Int32.Parse("39045"),Int32.Parse("12932"),Int32.Parse("14000"), "20151006213456789");
            Assert.That(_uut.ArrayToAircraftObject(correctArray).GetType() == ac.GetType());
        }

        [Test]
        public void getListofAircraftObjects_return_listofAircrafts()
        {
            Aircraft ac = new Aircraft("ATR423", Int32.Parse("39045"), Int32.Parse("12932"), Int32.Parse("14000"), "20151006213456789");
            List<Aircraft> lac = new List<Aircraft>();
            lac.Add(ac);
            string[] data = correctArray;
            Aircraft currentAircraft = new Aircraft(data[0], Int32.Parse(data[1]), Int32.Parse(data[2]), Int32.Parse(data[3]), data[4]);
            //Aircraft ak = _uut.ArrayToAircraftObject(correctArray);
            Assert.Contains(currentAircraft,_uut.getListofAircraftObjects(stringAircraft));
            //Assert.AreEqual(lac, _uut.getListofAircraftObjects(stringAircraft));
        }
    }
}
