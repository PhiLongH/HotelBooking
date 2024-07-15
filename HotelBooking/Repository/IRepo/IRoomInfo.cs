using HotelBooking.Model;

namespace HotelBooking.Repository.IRepo
{
    public interface IRoomInfo
    {
        public Task<List<RoomInformation>> GetAllAsync();
        public Task<RoomInformation> GetByIdAsync(int id);
    }
}
