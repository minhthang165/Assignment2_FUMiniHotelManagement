﻿using BusinessObjects.Enums;
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
        List<BookingReservation> GetBookingsListById(int CustomerId);
        List<BookingReservation> GetBookingList();
        void UpdateBooking(RoomInformation room, Customer customer, DateOnly StartDate, DateOnly EndDate, BookingStatus status);
        void DeleteBooking(BookingReservation bookingReservation);
        void CreateNewBooking(RoomInformation room, Customer customer, DateOnly StartDate, DateOnly EndDate);
        BookingReservation GetBookingByCustomerId(int CustomerId);
        BookingReservation GetBookingByBookingId(int BookingId);
    }
}
