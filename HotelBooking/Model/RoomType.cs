using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Model
{
    public class RoomType
    {
        [Key]
        public int RoomTypeID { get; set; }
        public string RoomTypeName { get; set; }
        public string TypeDescription { get; set; }
        public string TypeNote { get; set; }
    }
}
