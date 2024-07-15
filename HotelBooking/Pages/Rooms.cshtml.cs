using HotelBooking.Model;
using HotelBooking.Services.Implementation;
using HotelBooking.Services.Interfaces;
using HotelBooking.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelBooking.Pages
{
    public class RoomsModel : PageModel
    {
        private readonly IRoomInfoService _roomInfoService;
        private readonly IBookingServices _bookingRoomService;
        public RoomsModel(IRoomInfoService roomInfoService, IBookingServices bookingRoomService)
        {
            _roomInfoService = roomInfoService;
            _bookingRoomService = bookingRoomService;
        }

        public List<RoomViewModel> Rooms { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public async Task OnGetAsync()
        {
            Rooms = await _roomInfoService.GetAllRoomAsync();
        }
        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("UserEmail"); // Clear session or logout mechanism
            return RedirectToPage("/Index");
        }
        public async Task<IActionResult> OnPostBookingRoomAsync(int roomId, DateTime startDate, DateTime endDate, decimal roomPrice)
        {
            var userEmail = HttpContext.Session.GetString("UserEmail");
            var customerId = 3;
            if (string.IsNullOrEmpty(userEmail))
            {
                // Redirect to login if user is not logged in
                return RedirectToPage("/Login");
            }

            // Example of creating a booking detail
            var bookingDetail = new BookingDetail
            {
                RoomID = roomId,
                StartDate = startDate,
                EndDate = endDate, // Example end date
                ActualPrice = roomPrice,
            };

            // Call the booking service to handle the booking
            bool bookingSuccess = await _bookingRoomService.BookRoom(roomId, startDate, endDate, customerId);

            if (bookingSuccess)
            {
                // Redirect to a success page or display a success message
                return RedirectToPage("/BookingSuccess");
            }
            else
            {
                // Handle booking failure (e.g., display an error message)
                return Page();
            }
        }
    }
}
