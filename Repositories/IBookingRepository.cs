using BusinessObjects.Enums;
using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBookingRepository
    {
        List<object> GetBookings();
        void UpdateBooking(RoomInformation room, Customer customer, DateOnly StartDate, DateOnly EndDate, BookingStatus status);
        void DeleteBooking(BookingReservation bookingReservation);
        void CreateNewBooking(RoomInformation room, Customer customer, DateOnly StartDate, DateOnly EndDate);
        BookingReservation GetBookingById(int id);
    }
}
