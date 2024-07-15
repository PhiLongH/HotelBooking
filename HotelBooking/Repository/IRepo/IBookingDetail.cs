using HotelBooking.Model;

namespace HotelBooking.Repository.IRepo
{
    public interface IBookingDetailRepo
    {
        Task CreateBookingDetail(BookingDetail bookingDetail);
    }
}
