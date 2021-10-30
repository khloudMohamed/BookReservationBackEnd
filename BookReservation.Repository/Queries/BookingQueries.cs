using BookReservation.Repository.Entities;
using BookReservation.Repository.Interfaces;
using BookReservation.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservation.Repository.Queries
{
    public class BookingQueries: IBookingQueries
    {

        private BookReservationDbContext bookReservationContext;
        private IRecourceQueries resourceQueries;
        public BookingQueries(BookReservationDbContext _bookReservationDbContext,IRecourceQueries recourceQueries)
        {
            bookReservationContext = _bookReservationDbContext;
            resourceQueries = recourceQueries;
        }

        public Boolean SaveNewBooking(BookingDetails newbooking)
        {
            try {
                int totalQuantity = 0;
                var resource = resourceQueries.Get(newbooking.ResourceId);

                var MaxQuantity = resource.Quantity;
                var tempBookings = bookReservationContext.Bookings.Where(f => (f.DateFrom <= newbooking.DateFrom) && (f.DateTo >= newbooking.DateTo)).ToList();
                totalQuantity = tempBookings.Select(f => f.BookingQuantity).Sum();
                if (ValidateNewBooking(totalQuantity, MaxQuantity)) {
                    Booking booking = new Booking()
                    {
                        DateFrom = newbooking.DateFrom,
                        DateTo = newbooking.DateTo,
                        BookingQuantity = newbooking.BookingQuantity,
                        Resource = resource
                    };
                    var result = bookReservationContext.Bookings.Add(booking);
                    //Console.WriteLine();
                    bookReservationContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(Exception e) {
               return false;
            }
           
        }

        public Boolean ValidateNewBooking(int totalQuantity,int MaxQuantity)
        {
            try {
                if ((MaxQuantity - totalQuantity) <= 0)
                    return false;
                return true;
            }
            catch(Exception e) {
                return false;
            }
           
        }
    }
}
