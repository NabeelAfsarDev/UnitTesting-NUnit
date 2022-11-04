using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class BookingHelperTests_OverlappingBookingsExistTests
    {
        private Mock<IBookingRepository> _repo;

        /*
         * Test case 1: When booking status = "Cancelled" 
         * Test case 2: No overlapping books
         * Test Case 3: Contains overlapping booking
         */
        [SetUp]
        public void Setup()
        {
            _repo = new Mock<IBookingRepository>();
        }

        [Test]
        public void OverlappingBookingsExist_StatusCanceled_ReturnsEmptyString()
        {
            var booking = new Booking { Id = 1, Status = "Canceled" };

            var result = BookingHelper.OverlappingBookingsExist(booking, _repo.Object);

            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void OverlappingBookingsExist_NoOverlaps_ReturnsEmptyString()
        {
            _repo.Setup(r => r.GetBookings(1)).Returns(new List<Booking>());

            var result = BookingHelper.OverlappingBookingsExist(new Booking(), _repo.Object);

            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void OverlappingBookingsExist_ContainsOverlaps_ReturnsReference()
        {
            _repo.Setup(r => r.GetBookings(1)).Returns(new List<Booking>
            {
                new Booking{ Id = 1, Reference = "Booking1"}
            });
            
            var result = BookingHelper.OverlappingBookingsExist(new Booking { Id = 1}, _repo.Object);

            Assert.That(result, Is.EqualTo("Booking1"));
        }

        [Test]
        public void OverlappingBookingsExist_BookingStartsAndFinishesBeforeAnExistingBooking_ReturnsReference()
        {

        }
    }
}
