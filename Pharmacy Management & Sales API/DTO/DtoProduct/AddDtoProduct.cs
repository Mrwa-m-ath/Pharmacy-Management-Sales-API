using Pharmacy_Management___Sales_API.Model;

namespace Pharmacy_Management___Sales_API.DTO.DtoProduct
{
    public class AddDtoProduct
    {
        public string NameProduct { get; set; }
        public int Stock { get; set; }
        public int Quinte { get; set; }
        public int Cost { get; set; }
        public int IdCategpres { get; set; }
    }
}
