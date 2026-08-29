using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy_Management___Sales_API.Model
{
    public class Detalis
    {
     
        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public int idDetalis { get; set; }
        public double SubTotal { get; set; }
        public int TotalAmount { get; set; }
        public int NewStock { get; set; }
        public List<Product> products;
    }
}
