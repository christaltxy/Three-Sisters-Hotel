using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ThreeSistersHotel.Data;
using ThreeSistersHotel.Models;

namespace ThreeSistersHotel.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly ThreeSistersHotel.Data.ApplicationDbContext _context;

        public IndexModel(ThreeSistersHotel.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get;set; }

        public async Task<IActionResult> OnGetAsync(string sortOrder)
        {
            Booking = await _context.Booking
                .Include(b => b.TheCustomer)
                .Include(b => b.TheRoom).ToListAsync();

            if (String.IsNullOrEmpty(sortOrder))
            {
       
                sortOrder = "CheckIn_asc";
            }

            var bookings = (IQueryable<Booking>)_context.Booking;

            // Sort the movies by specified order
            switch (sortOrder)
            {
                case "title_asc":
                    bookings = bookings.OrderBy(b => b.CheckIn);
                    break;
                case "title_desc":
                    bookings = bookings.OrderByDescending(b => b.CheckIn);
                    break;
                case "price_asc":
                    bookings = bookings.OrderBy(b => (double)b.Cost);
                    break;
                case "price_desc":
                    bookings = bookings.OrderByDescending(b => (double)b.Cost);
                    break;
            }

            
            ViewData["NextCheckInOrder"] = sortOrder != "CheckIn_asc" ? "CheckIn_asc" : "title_desc";
            ViewData["NextCostOrder"] = sortOrder != "cost_asc" ? "cost_asc" : "cost_desc";

            // Access database to execute the query prepared above
            // Assign the returned movie list to the Movie property of this PageModel class
            Booking = await bookings.AsNoTracking().ToListAsync();

            return Page();
        }
    }
}
