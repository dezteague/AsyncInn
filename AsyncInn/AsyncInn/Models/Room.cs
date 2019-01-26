using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Layout RoomLayout { get; set; }

        //Navigation Properties 

        public HotelRoom HotelRoom { get; set; }
        public RoomAmenities RoomAmenities { get; set; }
    }

    public enum Layout
    {
        Studio,
        OneBedroom,
        TwoBedroom
    }
}
