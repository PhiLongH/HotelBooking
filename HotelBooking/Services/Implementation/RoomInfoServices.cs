using HotelBooking.Model;
using HotelBooking.Repository.IRepo;
using HotelBooking.Services.Interfaces;
using HotelBooking.ViewModel;

namespace HotelBooking.Services.Implementation
{
    public class RoomInfoServices : IRoomInfoService
    {
        private readonly IRoomInfo _roomInfoRepository;

        public RoomInfoServices(IRoomInfo roomInfoRepository)
        {
            _roomInfoRepository = roomInfoRepository;
        }

        public async Task<List<RoomViewModel>> GetAllRoomAsync()
        {
            var rooms = await _roomInfoRepository.GetAllAsync();
            return rooms.Select(room => new RoomViewModel
            {
                RoomID  = room.RoomID,
                RoomNumber = room.RoomNumber,
                RoomDetailDescription = room.RoomDetailDescription,
                RoomMaxCapacity = room.RoomMaxCapacity,
                RoomTypeName = room.RoomType.RoomTypeName,
                RoomStatus = room.RoomStatus,
                RoomPricePerDay = room.RoomPricePerDay
            }).ToList();
        }

        public async Task<RoomViewModel> GetRoomByIdAsync(int id)
        {
            var room = await _roomInfoRepository.GetByIdAsync(id);
            return new RoomViewModel
            {
                RoomID = room.RoomID,
                RoomNumber = room.RoomNumber,
                RoomDetailDescription = room.RoomDetailDescription,
                RoomMaxCapacity = room.RoomMaxCapacity,
                RoomTypeName = room.RoomType.RoomTypeName,
                RoomStatus = room.RoomStatus,
                RoomPricePerDay = room.RoomPricePerDay
            };
        }

    }
}
