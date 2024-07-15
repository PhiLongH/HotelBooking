using HotelBooking.Model;
using HotelBooking.Repository.IRepo;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Repository.Repo
{
	public class CustomerRepo: ICustomerRepo
	{
		private readonly HotelManagementContext _context;
		private readonly IHttpContextAccessor _httpContextAccessor;
		public CustomerRepo(HotelManagementContext context, IHttpContextAccessor httpContextAccessor)
		{
			_context = context;
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task<bool> AddCustomerAsync(Customer customer)
		{
			try
			{
				_context.Customer.Add(customer);
				await _context.SaveChangesAsync();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public async Task<bool> DeleteCustomerAsync(int id)
		{
			try
			{
				var customer = await _context.Customer.FindAsync(id);
				if (customer == null)
					return false;

				_context.Customer.Remove(customer);
				await _context.SaveChangesAsync();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
		{
			return await _context.Customer.ToListAsync();
		}

		public async Task<Customer> GetCustomerByIdAsync(int id)
		{
			return await _context.Customer.FindAsync(id);
		}
		public async Task<Customer> GetCustomerByEmail(string email)
		{
			return await _context.Customer.FirstOrDefaultAsync(u => u.EmailAddress == email);
		}

		public async Task<bool> LoginAsync(string email, string password)
		{
			var user = new Customer();
			user = await _context.Customer
				.FirstOrDefaultAsync(user => user.EmailAddress == email && user.Password == password);
			if (user != null)
			{
				_httpContextAccessor.HttpContext.Session.SetString("UserEmail", email);
				return true;
			}
			return false;
		}

		public async Task<bool> UpdateCustomerAsync(Customer customer)
		{
			try
			{
				_context.Entry(customer).State = EntityState.Modified;
				await _context.SaveChangesAsync();
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
