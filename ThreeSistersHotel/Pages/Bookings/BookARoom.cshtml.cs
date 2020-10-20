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
        private readonly ThreeSistersHotel.Data.ThreeSistersHotelContext _context;

        public BookARoomModel(ThreeSistersHotel.Data.ThreeSistersHotelContext context)
        {
            _context = context;
        }

        [BindProperty]
        // need 'using <ProjectName>.Models'
        public BookingViewModel CustomersInput { get; set; }

        // List of different bookings; for passing to Content file to display
        public IList<Room> DiffBookings { get; set; }

        //public BookingViewModel Booking { get; set; }

        // GET: Customers/BookARoom

        public IActionResult OnGet()
        {
            // Get the options for the Customer select list from the database
            // and save them in ViewData for passing to Content file
            ViewData["BookingList"] = new SelectList(_context.Customer, "Email", "Surname", "GivenName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // prepare the parameters to be inserted into the query
            var emailA = new SqliteParameter("personA", CustomersInput.CustomerA);

            var diffBookings = _context.Room.FromSqlRaw("select [Room].* from [Room] inner join [Booking] on "
                             + "[Room].ID = [Booking].MovieID where [Booking].MovieGoerEmail = @emailA and "
                             + "[Room].ID not in (select [Room].* from [Room] inner join [Booking] on [Room].ID = [Booking].MovieID)", emailA);

            // Run the query and save the results in DiffBookings for passing to content file
            DiffBookings = await diffBookings.ToListAsync();

            // Save the options for both dropdown lists in ViewData for passing to content file
            ViewData["BookingList"] = new SelectList(_context.Customer, "Email", "Surname", "GivenName");
            // invoke the content file

            return Page();
        }
    }
}