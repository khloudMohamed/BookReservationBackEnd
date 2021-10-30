using BookReservation.Repository.Entities;
using BookReservation.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservation.Repository.Interfaces
{
    public interface IBookingQueries
    {
        Boolean SaveNewBooking(BookingDetails booking);

    }
}
