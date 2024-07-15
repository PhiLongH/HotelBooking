using HotelBooking.Model;
using HotelBooking.Repository.IRepo;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Repository.Repo
{
    public class BookingReservationRepo : IBookingReservationRepo
    {
        private readonly HotelManagementContext _context;
        public BookingReservationRepo(HotelManagementContext context)
        {
            _context = context;
        }
        public async Task<int> CreateBookingReservation(BookingReservation bookingReservation)
        {
            int nextBookingReservationId = await CalculateNextBookingReservationId();
            bookingReservation.BookingReservationID = nextBookingReservationId;

            _context.BookingReservation.AddAsync(bookingReservation);
            await _context.SaveChangesAsync();
            return bookingReservation.BookingReservationID;
        }
        private async Task<int> CalculateNextBookingReservationId()
        {
            // Get the current maximum BookingReservationID in the table
            int currentMaxId = await _context.BookingReservation.MaxAsync(b => (int?)b.BookingReservationID) ?? 0;

            // Calculate the next ID
            int nextId = currentMaxId + 1;

            return nextId;
        }

    }
}
