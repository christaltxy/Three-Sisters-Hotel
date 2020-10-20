using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThreeSistersHotel.Models
{
    public class BookingViewModel
    {
        [Range(1,16)]
        public int RoomID { get; set; }

        [Display(Name = "Checking in Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}")]
        public DateTime CheckIn { get; set; }

        [Display(Name = "Checking out Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}")]
        public DateTime CheckOut { get; set; }

       
    }
}
