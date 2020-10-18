using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ThreeSistersHotel.Data;
using ThreeSistersHotel.Models;

namespace ThreeSistersHotel.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly ThreeSistersHotel.Data.ApplicationDbContext _context;

        public CreateModel(ThreeSistersHotel.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CustomerEmail"] = new SelectList(_context.Set<Customer>(), "Email", "Email");
        ViewData["RoomID"] = new SelectList(_context.Room, "ID", "Level");
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Booking.Add(Booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
