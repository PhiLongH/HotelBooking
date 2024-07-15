using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Model
{
    public class RoomInformation
    {
        [Key]
        public int RoomID { get; set; }
        public string RoomNumber { get; set; }
        public string RoomDetailDescription { get; set; }
        public int? RoomMaxCapacity { get; set; }
        public int RoomTypeID { get; set; }
        public byte? RoomStatus { get; set; }
        public decimal? RoomPricePerDay { get; set; }
        public virtual RoomType RoomType { get; set; }
    }
}
