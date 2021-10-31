using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using BookReservation.Repository.Interfaces;
using BookReservation.Repository.Entities;
using BookReservation.Repository.Models;

namespace BookReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookDetailsController : ControllerBase
    {
        private readonly IRecourceQueries recourceQueries;
        private readonly IBookingQueries bookingQueries;

        public BookDetailsController(IRecourceQueries recourceQueries,IBookingQueries bookingQueries)
        {
            this.recourceQueries = recourceQueries;
            this.bookingQueries = bookingQueries;
        }

        [HttpGet]
        [Route("GetList")]
        public List<Resource> Get()
        {
            return recourceQueries.Get();
        }

        [HttpGet]
        [Route("GetById")]
        public Resource Get(int id)
        {
            return recourceQueries.Get(id);
        }

        [HttpPost]
        [Route("BookResource")]
        public Boolean BookResource(BookingDetails newbooking)
        {
            if( bookingQueries.SaveNewBooking(newbooking))
            {
                Console.WriteLine("");
                return true;
            }
            return false;

        }
    }
}
