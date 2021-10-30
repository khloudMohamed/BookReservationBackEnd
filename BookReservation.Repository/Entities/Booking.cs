using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservation.Repository.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int BookingQuantity { get; set; } 
        public Resource Resource { get; set; }

    }
}
