using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic;
using AirTrafficMonitoringLogic.Interface;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TransponderReceiver;


namespace AirTrafficMonitoringUnitTest
{
    [TestFixture()]
    class Print_UnitTest_T4
    {
        private IPrint _print;
        List<Aircraft> aircraftList = new List<Aircraft>();

        [SetUp]
        public void SetUp()
        {
            Aircraft aircraft1 = new Aircraft("PKY304", 94273, 54214, 12300, "20180408143635889");
            Aircraft aircraft2 = new Aircraft("LPM304", 67390, 43672, 11900, "20180409143635888");
            aircraftList.Add(aircraft1);
            _print = new Print();
            
            //aircraftList.Add(aircraft2);
            
        }
        [Test]
        public void PrintData_()
        {
            
            using (StringWriter sw = new StringWriter())
            {
                string outputline = "Tag name is: PKY304 Current position is : 94273,54214 Current altitude is: 12300 current timestamp : 20180408143635889";
                Console.SetOut(sw);

                _print.PrintData(aircraftList);
                

                string expected = string.Format("Ploeh{0}", Environment.NewLine);
                Assert.AreEqual(expected, sw.ToString());
            }

            ////string outputline = "Tag name is: PKY304 Current position is : 94273,54214 Current altitude is: 12300 current timestamp : 20180408143635889";
            //_print.PrintData(aircraftList);
            //var currentConsoleOut = Console.Out;
            
            ////using (var consoleOutput = new ConsoleOutput())
            ////{
                

            ////    Assert.AreEqual(outputline, consoleOutput.GetOuput());
            ////}

            //Assert.AreEqual(outputline, currentConsoleOut);
        }
}
}
