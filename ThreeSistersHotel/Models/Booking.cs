using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThreeSistersHotel.Models
{
    public class Booking
    {
        // Primary key
        public int ID { get; set; }

        // Foreign key
        public int RoomID { get; set; }
        public string CustomerEmail { get; set; }

        [Display(Name = "Checking in Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}")]
        public DateTime CheckIn { get; set; }

        [Display(Name = "Checking out Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}")]
        public DateTime CheckOut { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = false)]
        public decimal Cost { get; set; }

        // Navigation properties
        public Room TheRoom { get; set; }
        public Customer TheCustomer { get; set; }
    }
}
