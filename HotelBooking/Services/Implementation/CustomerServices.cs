using HotelBooking.Model;
using HotelBooking.Repository.IRepo;
using HotelBooking.Repository.Repo;
using HotelBooking.Services.Interfaces;

namespace HotelBooking.Services.Implementation
{
	public class CustomerService : ICustomerServices
	{
		private readonly ICustomerRepo _customerRepo;

		public CustomerService(ICustomerRepo customerRepo)
		{
			_customerRepo = customerRepo;
		}

		public async Task<bool> AddCustomerAsync(Customer customer)
		{
			return await _customerRepo.AddCustomerAsync(customer);
		}

		public async Task<bool> DeleteCustomerAsync(int id)
		{
			return await _customerRepo.DeleteCustomerAsync(id);
		}

		public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
		{
			return await _customerRepo.GetAllCustomersAsync();
		}

		public async Task<Customer> GetCustomerByEmail(string email)
		{
			return await _customerRepo.GetCustomerByEmail(email);
		}

		public async Task<Customer> GetCustomerByIdAsync(int id)
		{
			return await _customerRepo.GetCustomerByIdAsync(id);
		}

		public async Task<bool> LoginAsync(string email, string password)
		{
			return await _customerRepo.LoginAsync(email, password);
		}

		public async Task<bool> UpdateCustomerAsync(Customer customer)
		{
			return await _customerRepo.UpdateCustomerAsync(customer);
		}
	}
}
