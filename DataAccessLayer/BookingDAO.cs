using BusinessObjects.Enums;
using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccessLayer
{
    public class BookingDAO
    {
        public static List<BookingReservation> GetBookingsListById(int CustomerId)
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

        public static List<BookingReservation> GetBookingsList()
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                var bookings = from br in context.BookingReservations
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

        public static void CreateNewBooking(RoomInformation room, Customer customer, DateOnly StartDate, DateOnly EndDate)
        {
            try
            {
                BookingReservation bookingReservation = new BookingReservation
                {
                    BookingDate = DateOnly.FromDateTime(DateTime.Now),
                    TotalPrice = (EndDate.DayNumber - StartDate.DayNumber) * room.RoomPricePerDay,
                    CustomerId = customer.CustomerId,
                    BookingStatus = 2
                };
                BookingDetail bookingDetail = new BookingDetail
                {
                    BookingReservationId = bookingReservation.BookingReservationId,
                    RoomId = room.RoomId,
                    StartDate = StartDate,
                    EndDate = EndDate
                };

                using var context = new FuminiHotelManagementContext();
                context.BookingReservations.Add(bookingReservation);
                context.BookingDetails.Add(bookingDetail);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateBooking(RoomInformation room, Customer customer, DateOnly StartDate, DateOnly EndDate, BookingStatus status)
        {
            try
            {
                BookingReservation bookingReservation = new BookingReservation
                {
                    BookingDate = DateOnly.FromDateTime(DateTime.Now),
                    TotalPrice = (EndDate.DayNumber - StartDate.DayNumber) * room.RoomPricePerDay,
                    CustomerId = customer.CustomerId,
                    BookingStatus = Convert.ToByte(status)
                };

                BookingDetail bookingDetail = new BookingDetail
                {
                    BookingReservationId = bookingReservation.BookingReservationId,
                    RoomId = room.RoomId,
                    StartDate = StartDate,
                    EndDate = EndDate
                };
                using var context = new FuminiHotelManagementContext();
                context.BookingReservations.Update(bookingReservation);
                context.BookingDetails.Update(bookingDetail);
                context.SaveChanges();
            } catch (Exception ex) 
            { 
                throw new Exception(ex.Message); 
            }
        }

        public static void DeleteBooking(BookingReservation reservation)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                context.BookingReservations.Remove(reservation);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static BookingReservation GetBookingReservationByCustomerId(int CustomerId)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                return context.BookingReservations.FirstOrDefault(b => b.CustomerId == CustomerId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static BookingReservation GetBookingReservationByBookingId(int id)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                return context.BookingReservations.FirstOrDefault(b => b.BookingReservationId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
