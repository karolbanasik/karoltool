using System;
using NUnit.Framework;
using TestDataTools.PeselTools;

namespace UnitTests
{
    [TestFixture]
    public class PeselTests
    {
        Generator generator;

        [SetUp]
        public void TestSetUp()
        {
            generator = new Generator();
        }

        [TestCase(null, null, null)]
        [TestCase(2099, null, null)]
        [TestCase(1800, null, null)]
        [TestCase(null, null, 31)]
        public void PositiveDateCases(int? year, int? month, int? day)
        {
            generator.ValidPesel(year, month, day);
        }

        [Test]
        public void PositiveCheckLength()
        {
            string pesel = generator.ValidPesel();
            Assert.AreEqual(11, pesel.Length);
        }
    }
}
