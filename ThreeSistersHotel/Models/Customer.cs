using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ThreeSistersHotel.Models
{
    public class Customer
    {
        // Primary key
        [Key, Required]
        [DataType(DataType.EmailAddress)]
        //[EmailAddress]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"[A-Z][a-z'-]{1,19}")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Given Name")]
        [RegularExpression(@"[A-Z][a-z'-]{1,19}")]
        public string GivenName { get; set; }

        [Required]
        [RegularExpression(@"^[0-8]{1}[0-9]{3}$", ErrorMessage = "Postcode must be exactly 4 digits, and cannot start with '9' for residential use.")]
        public string Postcode { get; set; }

        // Navigation properties
        public ICollection<Booking> TheBookings { get; set; }
    }
}
