using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Room
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Room Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Room Layout")]
        public int Layout { get; set; }

        public int AmenityCount { get; set; }

        //Navigation Properties 

        public ICollection<HotelRoom> HotelRoom { get; set; }
        public ICollection<RoomAmenities> RoomAmenities { get; set; }
    }

    public enum Layout
    {   
        [Display(Name="Studio")]
        Studio = 0,
        [Display(Name="One bedroom")]
        OneBedroom = 1,
        [Display(Name = "Two bedroom")]
        TwoBedroom = 2
    }
}
