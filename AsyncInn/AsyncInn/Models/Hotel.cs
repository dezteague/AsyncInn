using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Hotel
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Hotel Name:")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "City:")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Phone number:")]
        public string Phone { get; set; }

        //Navigation Properties

        public ICollection<HotelRoom> HotelRoom { get; set; }
    }
}
