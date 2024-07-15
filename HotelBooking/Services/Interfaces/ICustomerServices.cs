using HotelBooking.Model;

namespace HotelBooking.Services.Interfaces
{
	public interface ICustomerServices
	{
		Task<bool> LoginAsync(string email, string password);
		Task<IEnumerable<Customer>> GetAllCustomersAsync();
		Task<Customer> GetCustomerByIdAsync(int id);
		Task<bool> AddCustomerAsync(Customer customer);
		Task<Customer> GetCustomerByEmail(string email);
		Task<bool> UpdateCustomerAsync(Customer customer);
		Task<bool> DeleteCustomerAsync(int id);
	}
}
