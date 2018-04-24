using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic;
using AirTrafficMonitoringLogic.AircraftUtillity;
using AirTrafficMonitoringLogic.Interface;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TransponderReceiver;

namespace AirTrafficMonitoringIntegrationTest
{
    [TestFixture()]
    class IT3_2_MonitoringToPrint
    {
        private IAirCraftObjectsUtility _airCraftObjectsUtility;
        private RecieveAircrafts _recieveAircrafts;
        private MonitoringAirSpace _monitoringAirSpace;
        private ICourseAndVelocityCalculator _courseAndVelocityCalculator; 
        private ITransponderReceiver _receiver;   
        private IObserver _print;
        private List<Aircraft> _testlist;
        private Aircraft _aircraft1;
      

        [SetUp]
        public void Setup()
        {
            _courseAndVelocityCalculator = new CourseAndVelocityCalculator();
            _airCraftObjectsUtility = new AircraftObjectsUtility();
            _receiver = Substitute.For<ITransponderReceiver>();
            _recieveAircrafts = new RecieveAircrafts(_receiver, _airCraftObjectsUtility, _courseAndVelocityCalculator);
            _monitoringAirSpace = new MonitoringAirSpace(_recieveAircrafts);
          _print = new Print();
            _monitoringAirSpace.Attach(_print);

            _testlist = new List<Aircraft>();
            _aircraft1 = new Aircraft("VBF451", 67000, 28912, 7300, DateTime.ParseExact("20180408143814504", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            
            _testlist.Add(_aircraft1);

        }
        [Test]
        public void ConnectToPrint()
        {

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                var args = new RawTransponderDataEventArgs(new List<string> { "VBF451;67000;28912;7300;20180408143814504" });
                
                _recieveAircrafts.UpdateTransponderData(args);
            
               string expected = string.Format(_testlist[0].ToString() + "\r\n");
                Assert.AreEqual(expected, sw.ToString());
            }
        }
    }
}
