using MessagePack;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulkyBookWeb.Models
{
    public class Franchise
    {
        [Key("Id")]
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        // Navigation property
        public UserAccount User { get; set; }

    }
}
