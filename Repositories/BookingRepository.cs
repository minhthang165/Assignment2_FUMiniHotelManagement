﻿using BusinessObjects.Enums;
using BusinessObjects.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BookingRepository : IBookingRepository
    {
        public void CreateNewBooking(RoomInformation room, Customer customer, DateOnly StartDate, DateOnly EndDate) 
            => BookingDAO.CreateNewBooking(room, customer, StartDate, EndDate);

        public void DeleteBooking(BookingReservation bookingReservation) => BookingDAO.DeleteBooking(bookingReservation);

        public BookingReservation GetBookingById(int id) => BookingDAO.GetBookingReservationById(id);

        public List<object> GetBookings() => BookingDAO.GetBookings();

        public void UpdateBooking(RoomInformation room, Customer customer, DateOnly StartDate, DateOnly EndDate, BookingStatus status)
            => BookingDAO.UpdateBooking(room,customer, StartDate, EndDate, status);
    }
}