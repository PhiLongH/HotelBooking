using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Model
{
    public class BookingReservation
    {
        [Key]
        public int BookingReservationID { get; set; }
        public DateTime? BookingDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public int CustomerID { get; set; }
        public byte? BookingStatus { get; set; }
        public virtual ICollection<BookingDetail> BookingDetail { get; set; }
    }
}
