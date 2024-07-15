using HotelBooking.Model;
using HotelBooking.Repository.IRepo;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Repository.Repo
{
    public class RoomInfoRepo : IRoomInfo
    {
        private readonly HotelManagementContext _context;

        public RoomInfoRepo(HotelManagementContext context)
        {
            _context = context;
        }

        public async Task<List<RoomInformation>> GetAllAsync()
        {
            return await _context.RoomInformation.Include(r => r.RoomType).ToListAsync();
        }

        public async Task<RoomInformation> GetByIdAsync(int id)
        {
            return await _context.RoomInformation.Include(r => r.RoomType).FirstOrDefaultAsync(r => r.RoomID == id);
        }
    }
}
