using HotelBooking.Model;
using HotelBooking.Repository.IRepo;

namespace HotelBooking.Repository.Repo
{
    public class BookingDetailRepo : IBookingDetailRepo
    {
        private readonly HotelManagementContext _context;
        public BookingDetailRepo(HotelManagementContext context)
        {
            _context = context;
        }
        public async Task CreateBookingDetail(Model.BookingDetail bookingDetail)
        {
            _context.BookingDetail.AddAsync(bookingDetail);
            await _context.SaveChangesAsync();
        }
    }
}
