using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Model
{
    public class BookingDetail
    {
        [Key]
        public int BookingReservationID { get; set; }
        [Key]
        public int RoomID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal? ActualPrice { get; set; }
        public virtual BookingReservation BookingReservation { get; set; }

    }
}
