using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThreeSistersHotel.Models;

namespace ThreeSistersHotel.Data
{
    public class ThreeSistersHotelContext : DbContext
    {
        public ThreeSistersHotelContext (DbContextOptions<ThreeSistersHotelContext> options)
            : base(options)
        {
        }

        public DbSet<ThreeSistersHotel.Models.Room> Room { get; set; }
    }
}
