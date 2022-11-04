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
    public class FizBuzzTests
    {
        [Test]
        //Test to check against 3 and 5
        public void GetOuput_NumberIsDivisibleBy3And5_ReturnsFizzbuzz()
        {

            var result = FizzBuzz.GetOutput(15);

            Assert.That(result, Is.EqualTo("fizzbuzz").IgnoreCase);
        }

        [Test]
        public void GetOutput_NumberIsDivisibleByThree_ReturnsFizz()
        {
            var result = FizzBuzz.GetOutput(3);

            Assert.That(result, Is.EqualTo("fizz").IgnoreCase);
        }

        [Test]
        public void GetOutput_NumberIsDivisibleByFive_ReturnsBuzz()
        {
            var result = FizzBuzz.GetOutput(5);

            Assert.That(result, Is.EqualTo("buzz").IgnoreCase);
        }

        [Test]
        public void GetOutput_NumberNotDivisibleByThreeOrFive_ReturnsString()
        {
            var result = FizzBuzz.GetOutput(2);

            Assert.That(result, Is.EqualTo("2").IgnoreCase);
        }
    }
}
