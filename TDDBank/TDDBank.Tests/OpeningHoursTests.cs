using Microsoft.QualityTools.Testing.Fakes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TDDBank.Tests
{
    [TestFixture]
    class OpeningHoursTests
    {
        [Test]
        [TestCase(2020, 06, 26, 10, 29, false)]
        [TestCase(2020, 06, 26, 10, 30, true)]
        [TestCase(2020, 06, 26, 12, 0, true)]
        [TestCase(2020, 06, 26, 18, 59, true)]
        [TestCase(2020, 06, 26, 19, 0, false)]
        [TestCase(2020, 06, 27, 10, 29, false)]
        [TestCase(2020, 06, 27, 10, 30, true)]
        [TestCase(2020, 06, 27, 13, 59, true)]
        [TestCase(2020, 06, 27, 14, 0, false)]
        public void OpeningHours_IsOpen(int y, int m, int d, int h, int min, bool expected)
        {
            var oh = new OpeningHours();

            Assert.AreEqual(expected, oh.IsOpen(new DateTime(y, m, d, h, min, 0)));
        }

        [Test]
        public void OpeningHours_IsOpen_26_06_2020_12_00_true()
        {
            var oh = new OpeningHours();

            Assert.IsTrue(oh.IsOpen(new DateTime(2020, 06, 26, 12, 0, 0)));
        }

        [Test]
        public void OpeningHours_IsOpen_true()
        {
            var oh = new OpeningHours();

            Assert.IsTrue(oh.IsOpen(new DateTime(2020, 06, 26, 12, 0, 0)));
            Assert.IsTrue(oh.IsOpen(new DateTime(2020, 06, 26, 10, 30, 0)));
            Assert.IsTrue(oh.IsOpen(new DateTime(2020, 06, 26, 14, 0, 0)));
            Assert.IsTrue(oh.IsOpen(new DateTime(2020, 06, 26, 18, 0, 0)));
            Assert.IsTrue(oh.IsOpen(new DateTime(2020, 06, 26, 18, 59, 0)));
        }

        [Test]
        public void OpeningHours_IsNowOpen()
        {
            var oh = new OpeningHours();

            using (ShimsContext.Create())
            {
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2020, 6, 22, 10, 29, 0);
                Assert.IsFalse(oh.IsNowOpen());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2020, 6, 22, 10, 30, 0);
                Assert.IsTrue(oh.IsNowOpen());
            }
        }

        [Test]
        public void Fakes_File_Exists()
        {
            using (ShimsContext.Create())
            {
                var rsult = System.IO.File.Exists("k:\\dieseDateiIstNichtDa.txt");
                Assert.IsFalse(rsult);

                System.IO.Fakes.ShimFile.ExistsString = pfad => true;

                rsult = System.IO.File.Exists("k:\\dieseDateiIstNichtDa.txt");
                Assert.IsTrue(rsult);
            }
        }


    }
}
