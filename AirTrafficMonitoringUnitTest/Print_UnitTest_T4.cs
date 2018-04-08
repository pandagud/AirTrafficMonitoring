using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TransponderReceiver;

namespace AirTrafficMonitoringUnitTest
{
    [TestFixture()]
    class Print_UnitTest_T4
    {
        private Print _print;
        

        [SetUp]
        public void SetUp()
        {
            Aircraft aircraft1 = new Aircraft("PKY304", 94273, 54214, 12300, "20180408143635889");
            Aircraft aircraft2 = new Aircraft("LPM304", 67390, 43672, 11900, "20180409143635888");
            List<Aircraft> aircraftList = new List<Aircraft>();
            aircraftList.Add(aircraft1);
            aircraftList.Add(aircraft2);
        }
        [Test]
        public void PrintData_()
        {
            Assert.That(_print.)
        }
   


}
}
