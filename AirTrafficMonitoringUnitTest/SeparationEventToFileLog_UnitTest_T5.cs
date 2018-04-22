using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoringLogic;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Text;
using System.IO;

namespace AirTrafficMonitoringUnitTest
{
    [TestFixture]
    class SeparationEventToFileLog_UnitTest_T5
    {
        private SeparationEventToFileLog _uut;
        private Aircraft _testAircraft1;
        private Aircraft _testAircraft2;
        private string _tags;
        private string _date;
        private string _path;
        [SetUp]
        public void Setup()
        {
            _uut = new SeparationEventToFileLog();
            _testAircraft1 = new Aircraft("ATR423", 10000, 10000, 20000, DateTime.ParseExact("20151006213456789", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            _testAircraft2 = new Aircraft("ATR424", 10000, 10500, 20000, DateTime.ParseExact("20151006213456789", "yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture));
            _tags = "ATR549, RTK985";
            _date = "20151006213456789";
            _path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


    }
        [Test]
        public void WriteToFile()
        {
            _uut.writeToFile(_tags,_date);
            var fileText = File.ReadLines(_path + @"SeparationEvents.txt");
            Assert.IsTrue(fileText.ToString().Length > 1);
        }

    }
}
