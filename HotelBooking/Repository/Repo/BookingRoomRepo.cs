using HotelBooking.Model;
using HotelBooking.Repository.IRepo;

namespace HotelBooking.Repository.Repo
{
    public class BookingRoomRepo : IBookingRoomRepo
    {
        private readonly HotelManagementContext _context;
        public BookingRoomRepo(HotelManagementContext context)
        {
            _context = context;
        }
        public async Task<bool> BookingRoom(BookingDetail detail)
        {   
            if(detail == null)
            {
                return false;
            }
            await _context.BookingDetail.AddAsync(detail);
			await _context.SaveChangesAsync();
			return true;
        }
    }
}
