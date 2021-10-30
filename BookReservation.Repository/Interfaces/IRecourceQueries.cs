using BookReservation.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservation.Repository.Interfaces
{
    public interface IRecourceQueries
    {
        List<Resource> Get();
        Resource Get(int id);
    }
}
