using HotelBooking.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelBooking.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ICustomerServices _loginService;

        [BindProperty]
        public InputModel Input { get; set; }
        public LoginModel(ICustomerServices loginService)
        {
            _loginService = loginService;
        }
        public class InputModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var loginResult = await _loginService.LoginAsync(Input.Username, Input.Password);

            if (loginResult)
            {
				HttpContext.Session.SetString("UserEmail", Input.Username);
				return RedirectToPage("/Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }
        }

    }
}
