using HotelBooking.Model;

namespace HotelBooking.Repository.IRepo
{
	public interface ICustomerRepo
	{
		public Task<bool> LoginAsync(string email, string password);
		public Task<IEnumerable<Customer>> GetAllCustomersAsync();
		public Task<Customer> GetCustomerByIdAsync(int id);
		public Task<bool> AddCustomerAsync(Customer customer);
		public Task<Customer> GetCustomerByEmail(string email);
		public Task<bool> UpdateCustomerAsync(Customer customer);
		public Task<bool> DeleteCustomerAsync(int id);
	}
}
