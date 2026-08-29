using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy_Management___Sales_API.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public int idUser { get; set; }
        public string NameUser { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Gender { get; set; }
        public DateTime Expired { get; set; }
        public string Email { get; set; }
        public string Token { get; set; } = "";
        public string RefreshToken { get; set; } = "";
    }
}
