using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThreeSistersHotel.Models
{
    public class Room
    {
        // Primary key
        [Display(Name = "Room ID")]
        public int ID { get; set; }

        [Required]
        [RegularExpression(@"^[G|1|2|3]$", ErrorMessage = "The level of this room has to contain exactly one character of 'G', '1', '2' or '3'.")]
        public string Level { get; set; }

        [RegularExpression(@"^[1|2|3]", ErrorMessage = "The number of beds in a room can only be 1, 2 or 3.")]
        public int BedCount { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = false)]
        [Range(50.00, 300.00, ErrorMessage = "A room costs between $50 and $300!")]
        public decimal Price { get; set; }

        // Navigation properties
        public ICollection<Booking> TheBookings { get; set; }
    }
}
