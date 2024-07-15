using HotelBooking.Model;

namespace HotelBooking.Repository.IRepo
{
    public interface IBookingRoomRepo
    {
        public Task<bool> BookingRoom(BookingDetail detail);
    }
}
