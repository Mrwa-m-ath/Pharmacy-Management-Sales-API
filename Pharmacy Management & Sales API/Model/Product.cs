using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy_Management___Sales_API.Model
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public int IdProduct { get; set; }
        public string NameProduct { get; set; }
        public int Stock { get; set; }
        public int Quinte { get; set; }
         public Categpres categpres { get; set; }
        public Sales sales { get; set; }
        public int Cost { get; set; }
        public int IdCategpres { get; set; }
        public int idDetalis { get; set; }
    }
}
