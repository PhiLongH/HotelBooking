using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Model
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string CustomerFullName { get; set; }
        public string Telephone { get; set; }
        public string EmailAddress { get; set; }
        public DateTime? CustomerBirthday { get; set; }
        public byte? CustomerStatus { get; set; }
        public string Password { get; set; }
    }
}
