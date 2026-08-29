namespace Pharmacy_Management___Sales_API.DTO.SaleDto
{
    public class GetAllDate
    {
        public int Cost { get; set; }
        public int Total { get; set; }
        public string PaymentMethods { get; set; }
        public int IdProduct { get; set; }
        public int idCustomer { get; set; }
        public int Quantity { get; set; }
    }
}
