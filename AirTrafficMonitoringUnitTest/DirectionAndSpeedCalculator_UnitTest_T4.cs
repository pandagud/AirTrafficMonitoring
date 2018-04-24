using System;
using System.Collections.Generic;
using NUnit.Framework;
using AirTrafficMonitoringLogic;
using AirTrafficMonitoringLogic.AircraftUtillity;

namespace AirTrafficMonitoringUnitTest
{
    [TestFixture]
    public class DirectionAndSpeedCalculator_UnitTest_T4
    {
        private Aircraft ac;
        private Aircraft ac1;
        private Aircraft ac2;
        private List<Aircraft> NewListAc;
        private List<Aircraft> OldListAc;
        private List<Aircraft> SecondNewListAc;
        private CourseAndVelocityCalculator _uut;

        [SetUp]
        public void SetUp()
        {
            _uut = new CourseAndVelocityCalculator();
            ac = new Aircraft("Test",15000,15000,5000,DateTime.Now.AddSeconds(1));
            ac1 = new Aircraft("Test2",15100,14900,5100,DateTime.Now);
            ac2 = new Aircraft("Test",15000,15000,5000,DateTime.Now);
            NewListAc = new List<Aircraft>
            {
                ac
            };

            OldListAc = new List<Aircraft>
            {
                ac2
            };
            SecondNewListAc = new List<Aircraft>
            {
                ac,
                ac1
            };
            _uut.CalculateBoth(OldListAc);
        }

        #region CalculateDirection test-cases

        [Test]
        public void CalculateDirection_CourseNorth_0()
        {
            NewListAc[0]._xcoordinate = NewListAc[0]._xcoordinate + 100;
            _uut.CalculateDirection(NewListAc);
            Assert.AreEqual(0, NewListAc[0].Course);
        }


        [Test]
        public void CalculateDirection_CourseSouth_180()
        {
            NewListAc[0]._xcoordinate = NewListAc[0]._xcoordinate - 100;
            _uut.CalculateDirection(NewListAc);
            Assert.AreEqual(180, NewListAc[0].Course);
        }

        [Test]
        public void CalculateDirection_CourseEast_90()
        {
            NewListAc[0]._ycoordinate = NewListAc[0]._ycoordinate + 100;
            _uut.CalculateDirection(NewListAc);
            Assert.AreEqual(90, NewListAc[0].Course);
        }


        [Test]
        public void CalculateDirection_CourseWest_Negative90()
        {
            NewListAc[0]._ycoordinate = NewListAc[0]._ycoordinate / 100;
            _uut.CalculateDirection(NewListAc);
            Assert.AreEqual(-90, NewListAc[0].Course);
        }

        [Test]
        public void CalculateDirection_CourseSouth_Not0()
        {
            NewListAc[0]._xcoordinate = NewListAc[0]._xcoordinate - 100;
            _uut.CalculateDirection(NewListAc);
            Assert.AreNotEqual(0, NewListAc[0].Course);
        }

        #endregion

        #region CalculateSpeed test-cases

        [Test]
        public void CalculateSpeed_SpeedOnlyXCoordinate_100M_S()
        {
            NewListAc[0]._xcoordinate = NewListAc[0]._xcoordinate + 100;
            _uut.CalculateSpeed(NewListAc);
            Assert.AreEqual(100, NewListAc[0].Velocity);
        }

        [Test]
        public void CalculateSpeed_SpeedXAndY_100M_S()
        {
            NewListAc[0]._xcoordinate = NewListAc[0]._xcoordinate - 100;
            NewListAc[0]._ycoordinate = NewListAc[0]._ycoordinate - 300;
            _uut.CalculateSpeed(NewListAc);
            Assert.AreEqual(316, NewListAc[0].Velocity);
        }

        [Test]
        public void CalculateSpeed_SpeedXAndYAndAltitude_100M_S()
        {
            NewListAc[0]._xcoordinate = NewListAc[0]._xcoordinate + 150;
            NewListAc[0]._ycoordinate = NewListAc[0]._ycoordinate - 200;
            NewListAc[0]._altitude = NewListAc[0]._altitude + 100;
            _uut.CalculateSpeed(NewListAc);
            Assert.AreEqual(269, NewListAc[0].Velocity);
        }


        [Test]
        public void CalculateSpeed_SpeedOnlyAltitude_100M_S()
        {
            NewListAc[0]._altitude = NewListAc[0]._altitude + 100;
            _uut.CalculateSpeed(NewListAc);
            Assert.AreEqual(100, NewListAc[0].Velocity);
        }


        #endregion

        #region SortAircraftList test-cases

        [Test]
        public void SortAircraftList_DifferentSizeList_LengthIs1()
        {
            _uut.SortAircraftList(SecondNewListAc);
            Assert.AreEqual(1, SecondNewListAc.Count);
        }

        [Test]
        public void SortAircraftList_DifferentSizeList_CorrectElement()
        {
            _uut.SortAircraftList(SecondNewListAc);
            Assert.AreEqual(OldListAc[0]._tag, SecondNewListAc[0]._tag);
        }

        #endregion

        #region CalculateBoth test-cases

        [Test]
        public void CalculateBoth_SameListTwice_ListsAreSame()
        {
            Assert.AreSame(OldListAc,_uut.CalculateBoth(OldListAc));
        }

        [Test]
        public void CalculateBoth_VelocityCalculated_Yes()
        {
            SecondNewListAc[0]._xcoordinate = SecondNewListAc[0]._xcoordinate + 100;
            _uut.CalculateBoth(SecondNewListAc);
            Assert.AreNotEqual(0, SecondNewListAc[0].Velocity);
        }

        [Test]
        public void CalculateBoth_CourseCalculated_Yes()
        {
            SecondNewListAc[0]._ycoordinate = SecondNewListAc[0]._ycoordinate + 100;
            _uut.CalculateBoth(SecondNewListAc);
            Assert.AreNotEqual(0, SecondNewListAc[0].Course);
        }

        #endregion

    }
}