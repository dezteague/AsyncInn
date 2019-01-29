using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class HotelRoom
    {
        public int HotelID { get; set; }

        [Display(Name = "Room Number")]
        public int RoomNumber { get; set; }
        public int RoomID { get; set; }

        [Display(Name= "Nightly Rate")]
        public decimal Rate { get; set; }

        [Display(Name = "Pets Allowed")]
        public bool PetFriendly { get; set; }

        //Navigation Properties

        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
    }
}
