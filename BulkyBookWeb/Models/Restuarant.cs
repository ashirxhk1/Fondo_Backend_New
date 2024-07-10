using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BulkyBookWeb.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string RestaurantName { get; set; }
        public DateTime StartDate { get; set; }
        public int Specialty { get; set; }
        public string ReferenceSite { get; set; }
        public int Neighborhood { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string OutsideNumber { get; set; }
        public string InnerNumber { get; set; }
        public string ContactName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
        public UserAccount User { get; set; }
    }
}
