using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class CalculateDemeritPointsTests
    {
        [Test]
        [TestCase(0, 0)]
        [TestCase(64, 0)]
        [TestCase(65, 0)]
        [TestCase(66, 0)]
        [TestCase(70, 1)]
        [TestCase(75, 2)]
        public void CalculateDemeritPoints_WhenCalled_ReturnsDemeritPoints(int speed, int output)
        {
            var demeritCalc = new DemeritPointsCalculator();

            var result = demeritCalc.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(output));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedIsOver300_ThrowArgumentOutOfRangeException(int speed)
        {
            var demeritCalc = new DemeritPointsCalculator();

            Assert.That(() => demeritCalc.CalculateDemeritPoints(speed), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());

        }

    }
}
