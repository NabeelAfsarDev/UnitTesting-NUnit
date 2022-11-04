using NUnit.Framework;
using System;
using TestNinja.Fundamentals;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        private Fundamentals.Math _math;
        // Set up
        //Tear down
        [SetUp]
        public void SetUp()
        {
            _math = new Fundamentals.Math();
        }

        [Test]
       // [Ignore("Because I wanted to!")]
        public void Add_WhenCalled_ReturnSumOfArguments()
        {

            var result = _math.Add(1, 2);

            Assert.That(result, Is.EqualTo(3));
            
        }

        [Test]
        [TestCase(2,1,2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenCalled_ReturnGreaterArgument(int a, int b, int expectedResult)
        {
            var result = _math.Max(a, b);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUptoLimit()
        {
            var result = _math.GetOddNumbers(5);

        //    Assert.That(result, Is.Not.Empty);

        //    Assert.That(result.Count(), Is.EqualTo(3));
        //    Assert.That(result, Does.Contain(1));
        //    Assert.That(result, Does.Contain(3));

         //   Assert.That(result, Does.Contain(5));
            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));

        }
    }
}
