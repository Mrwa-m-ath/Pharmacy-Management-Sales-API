using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy_Management___Sales_API.Model
{
    public class Pharmacy
    {
   

        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public int idPharmacy { get; set; }
        public string NamePhaermacy { get; set; }
        public string Place { get; set; }
        public string Statas { get; set; }


    }
}
