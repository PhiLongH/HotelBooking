using HotelBooking.Model;

namespace HotelBooking.Services.Interfaces
{
    public interface IBookingServices
    {
        public Task<bool> BookRoom(int roomId, DateTime startDate, DateTime endDate, int customerId);
    }
}
