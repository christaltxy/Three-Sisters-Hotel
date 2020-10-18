using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ThreeSistersHotel.Models;

namespace ThreeSistersHotel.Pages.Customers
{
    [Authorize(Roles = "Customers")]
    public class MyDetailsModel : PageModel
    {
        private readonly ThreeSistersHotel.Data.ApplicationDbContext _context;

        public MyDetailsModel(ThreeSistersHotel.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CustomerViewModel Myself { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // retrieve the logged-in user's email
            // need to add "using System.Security.Claims;"
            string _email = User.FindFirst(ClaimTypes.Name).Value;

            Customer customer = await _context.Customer.FirstOrDefaultAsync(m => m.Email == _email);

            if (customer != null)
            {
                // The user has been created in the database
                ViewData["ExistInDB"] = "true";
                Myself = new CustomerViewModel
                {
                    // Retrieve his/her details for display in the web form
                    GivenName = customer.GivenName,
                    Surname = customer.Surname,
                    Postcode = customer.Postcode
                };
            }
            else
            {
                ViewData["ExistInDB"] = "false";
            }

            return Page();
        }

     
        public async Task<IActionResult> OnPostAsync()
        {
            // retrieve the logged-in user's email
            // need to add "using System.Security.Claims;"
            string _email = User.FindFirst(ClaimTypes.Name).Value;

            Customer customer = await _context.Customer.FirstOrDefaultAsync(m => m.Email == _email);

            if (customer != null)
            {
                // This ViewData entry is needed in the content file
                // The user has been created in the database
                ViewData["ExistInDB"] = "true";
            }
            else
            {
                ViewData["ExistInDB"] = "false";
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (customer == null)
            {
               
                customer = new Customer();
            }

            
            customer.Email = _email;
            customer.GivenName = Myself.GivenName;
            customer.Surname = Myself.Surname;
            customer.Postcode = Myself.Postcode;

            if ((string)ViewData["ExistInDB"] == "true")
            {
                _context.Attach(customer).State = EntityState.Modified;
            }
            else
            {
                _context.Customer.Add(customer);
            }

            try  // catching the conflict of editing this record concurrently
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            ViewData["SuccessDB"] = "success";
            return Page();
        }


    }
}