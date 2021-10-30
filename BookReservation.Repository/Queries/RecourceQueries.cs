using BookReservation.Repository.Entities;
using BookReservation.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookReservation.Repository.Queries
{
    public class RecourceQueries: IRecourceQueries
    {
        
        private BookReservationDbContext bookReservationContext;

        public RecourceQueries(BookReservationDbContext _bookReservationDbContext)
        {
            bookReservationContext = _bookReservationDbContext;
        }
        public List<Resource> Get()
        {
            try {
                return bookReservationContext.Resources.Include(s => s.Bookings).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public Resource Get(int id)
        {
            try 
            { 
                return bookReservationContext.Resources.Include(s=>s.Bookings).FirstOrDefault(f => f.Id == id);
            }
            catch (Exception e)
            {
                return null;
            }
}

    }
}
