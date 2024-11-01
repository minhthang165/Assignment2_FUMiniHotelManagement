﻿using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class BookingReservation
{
    public int BookingReservationId { get; set; }

    public DateOnly? BookingDate { get; set; }

    public decimal? TotalPrice { get; set; }

    public int CustomerId { get; set; }

    public byte? BookingStatus { get; set; }

    public virtual ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();

    public virtual Customer Customer { get; set; } = null!;
    public override string ToString()
    {
        return $"BookingReservationId: {BookingReservationId}, " +
               $"BookingDate: {BookingDate?.ToString("yyyy-MM-dd") ?? "N/A"}, " +
               $"TotalPrice: {TotalPrice?.ToString("C") ?? "N/A"}, " +
               $"CustomerId: {CustomerId}, " +
               $"BookingStatus: {BookingStatus}";
    }

}
