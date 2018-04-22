using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AirTrafficMonitoringUnitTest
{
    [TestFixture]
    class SeparationEventToFileLog_UnitTest_T5
    {
        [Test]
        public void WriteMovieListToFileTest1()
        {
            Movie movie1 = new Movie("Title", "Genre", "Actor", "Year");
            movieSystem.AddMovie(movie1);
            movieSystem.WriteMovieListToFile("MovieListTEST.txt");

            var fileText = File.ReadLines("MovieListTEST.txt");
            Assert.IsTrue(fileText.ToString().Length > 1);
        }



        private string test = "tag1, tag2 and time of occurence";
        private string HeaderOfFile = "This txt file contains all the raised separation events";
        private string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public SeparationEventToFileLog()
        {
            File.WriteAllText(path + @"SeparationEvents.txt", HeaderOfFile);
        }

        public void writeToFile() // indsæt i header den string der skal udskrives og sæt den ind i stedet for test.
        {
            File.AppendAllText(path + @"SeparationEvents.txt", test);
        }
    }
}
