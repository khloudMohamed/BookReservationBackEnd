using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservation.Repository.Models
{
    public class BookingDetails
    {
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int BookingQuantity { get; set; }
        public int ResourceId { get; set; }

    }
}
