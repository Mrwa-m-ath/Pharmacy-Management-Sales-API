using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy_Management___Sales_API.Model
{
    public class Categpres
    {
        [Key]
        [DatabaseGenerated(databaseGeneratedOption:DatabaseGeneratedOption.Identity)]
        public int IdCategpres { get; set; }
        public string NameCategpres { get; set; }
        public string Image { get; set; }
        public List<Product> products { get; set; }
    }
}
