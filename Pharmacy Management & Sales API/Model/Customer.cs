using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy_Management___Sales_API.Model
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public int idCustomer { get; set; }
        public  string NameCustomer { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public Sales sales { get; set; }
    }
}
