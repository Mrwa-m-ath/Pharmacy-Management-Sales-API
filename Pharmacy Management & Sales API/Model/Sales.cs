using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy_Management___Sales_API.Model
{
    public class Sales
    {
        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]

        public int idSales { get; set; }
        public int Cost { get; set; }
        public int Total { get; set; }
        public string PaymentMethods { get; set; }
        public List <Customer> customers { get; set; }
        public List<Product> Products { get; set; }
        public int idCustomer { get; set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }

    }
}
