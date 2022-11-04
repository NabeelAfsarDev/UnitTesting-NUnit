using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IBookingRepository
    {
        IEnumerable<Booking> GetBookings(int id);
    }

    public class BookingRepository : IBookingRepository
    {
        public IQueryable<Booking> GetActiveBookings()
        {
            var unitOfWork = new UnitOfWork();
            var bookings =
               unitOfWork.Query<Booking>()
                   .Where(
                       b => b.Id != id && b.Status != "Cancelled");
            return bookings;
        }


        public IEnumerable<Booking> GetBookings(int id)
        {
            
        }
    }

    public class UnitOfWork
    {
        public IQueryable<T> Query<T>()
        {
            return new List<T>().AsQueryable();
        }
    }
}
