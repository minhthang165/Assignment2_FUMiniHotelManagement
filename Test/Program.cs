

using BusinessObjects.Models;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                var bookings = from br in context.BookingReservations
                               where br.CustomerId == CustomerId
                               select new BookingReservation
                               {
                                   BookingReservationId = br.BookingReservationId,
                                   BookingDate = br.BookingDate,
                                   TotalPrice = br.TotalPrice,
                                   BookingStatus = br.BookingStatus,
                                   BookingDetails = br.BookingDetails.ToList(),
                                   Customer = br.Customer
                               };
                return bookings.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
