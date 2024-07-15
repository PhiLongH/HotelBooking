using HotelBooking.Model;

namespace HotelBooking.Repository.IRepo
{
    public interface IBookingReservationRepo
    {
        Task<int> CreateBookingReservation(BookingReservation bookingReservation);
    }
}
