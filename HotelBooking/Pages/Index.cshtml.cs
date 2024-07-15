﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelBooking.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
		public IActionResult OnGetLogout()
		{
			HttpContext.Session.Remove("UserEmail"); // Clear session or logout mechanism
			return RedirectToPage("/Index");
		}
	}
}
