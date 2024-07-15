using HotelBooking.Model;
using HotelBooking.ViewModel;

namespace HotelBooking.Services.Interfaces
{
    public interface IRoomInfoService
    {
        public Task<List<RoomViewModel>> GetAllRoomAsync();
        public Task<RoomViewModel> GetRoomByIdAsync(int id);

    }
}
