using BookReservation.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace BookReservation.Repository
{
    public class BookReservationDbContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Resource> Resources { get; set; }

        public BookReservationDbContext(DbContextOptions<BookReservationDbContext> options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>()
                .HasMany(c => c.Bookings)
                .WithOne(e => e.Resource);
        }
    }
}
