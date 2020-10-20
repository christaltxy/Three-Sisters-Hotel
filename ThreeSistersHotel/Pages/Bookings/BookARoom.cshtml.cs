using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using ThreeSistersHotel.Models;

namespace ThreeSistersHotel.Pages.Bookings
{
    public class BookARoomModel : PageModel
    {
        private readonly ThreeSistersHotel.Data.ApplicationDbContext _context;

        public BookARoomModel(ThreeSistersHotel.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public BookingViewModel Booking { get; set; }

        public IActionResult OnGet()
        {
            // Get the options for the MovieGoer select list from the database
            // and save them in ViewData for passing to Content file
          //  ViewData["Booking"] = new SelectList(_context.Booking, "CheckIn", "CheckOut");
            return Page();
        }

       /* public async Task<IActionResult> OnPostAsync()
        {


        }
        */
    }
}