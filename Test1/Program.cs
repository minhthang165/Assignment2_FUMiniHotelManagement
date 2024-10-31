using DataAccessLayer;

namespace Test1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bookings = BookingDAO.GetBookingReservationById(id);
            foreach (var booking in bookings)
            {
                Console.WriteLine(booking.BookingReservationId);
                foreach(var bookingDetail in booking.BookingDetail)
                {
                    Console.Write(bookingDetail.ActualPrice);
                }
            }
        }
    }
}
