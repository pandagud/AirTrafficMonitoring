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
    //Vi tester ikke PrintData metoden, da vi antager at Console.Writeline() virker. 
    //Derfor testes blot ToString() metoden. 
    [TestFixture()]
    class ToString_UnitTest_T4
    {
        Aircraft _aircraft;

        [SetUp]
        public void SetUp()
        {
             _aircraft= new Aircraft("PKY304", 94273, 54214, 12300, "20180408143635889");
        }

        [Test]
        public void ToString_is_true()
        {
            string expectedOutputline = "Tag name is: PKY304 Current position is : 94273,54214 Current altitude is :12300 current timestamp :20180408143635889";
            string outputline = _aircraft.ToString();
            Assert.AreEqual(outputline, expectedOutputline);
        }
        
        
        
}
}
