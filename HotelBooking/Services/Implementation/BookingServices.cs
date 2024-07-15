using HotelBooking.Model;
using HotelBooking.Repository.IRepo;
using HotelBooking.Services.Interfaces;

namespace HotelBooking.Services.Implementation
{
    public class BookingServices: IBookingServices
    {
        private readonly IBookingReservationRepo _bookingReservationRepo;
        private readonly IBookingDetailRepo _bookingDetailRepo;
        private readonly IRoomInfo _roomInformationRepo;

        public BookingServices(IBookingReservationRepo bookingReservationRepo,
                              IBookingDetailRepo bookingDetailRepo,
                              IRoomInfo roomInformationRepo)
        {
            _bookingReservationRepo = bookingReservationRepo;
            _bookingDetailRepo = bookingDetailRepo;
            _roomInformationRepo = roomInformationRepo;
        }

        public async Task<bool> BookRoom(int roomId, DateTime startDate, DateTime endDate, int customerId)
        {
            // Calculate total price (assuming a simplistic calculation for demonstration)
            decimal totalPrice = await CalculateTotalPrice(roomId, startDate, endDate);

            // Create booking reservation
            var bookingReservation = new BookingReservation
            {
                BookingDate = DateTime.Now,
                TotalPrice = totalPrice,
                CustomerID = customerId,
                BookingStatus = 1 // Assuming 1 represents 'Confirmed' status
            };

            // Save booking reservation to database
            int bookingReservationId = await _bookingReservationRepo.CreateBookingReservation(bookingReservation);

            // Create booking detail
            var bookingDetail = new BookingDetail
            {
                BookingReservationID = bookingReservationId,
                RoomID = roomId,
                StartDate = startDate,
                EndDate = endDate,
                ActualPrice = totalPrice // You can adjust this based on any pricing rules
            };

            // Save booking detail to database
            await _bookingDetailRepo.CreateBookingDetail(bookingDetail);

            return true; // Booking successful
        }

        private async Task<decimal> CalculateTotalPrice(int roomId, DateTime startDate, DateTime endDate)
        {
            // You can implement your pricing logic here (e.g., based on room rate, duration, etc.)
            var roomInfo = await _roomInformationRepo.GetByIdAsync(roomId);
            decimal roomPricePerDay = roomInfo.RoomPricePerDay ?? 0;
            int totalDays = (int)(endDate - startDate).TotalDays;
            return roomPricePerDay * totalDays;
        }
    }
}

