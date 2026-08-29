using Pharmacy_Management___Sales_API.DTO.SaleDto;

namespace Pharmacy_Management___Sales_API.Servies.SaleServies
{
    public interface ISaleServies 
    {
        public   Task<String> AddNewSale(AddSaleDto Add);
        public   Task<string> Remove(int id);
        public Task<List<GetAllDate>> GetAllSale();
        public Task<string> UpdateAsync(UpdateSaleDto dto, int id);
    }
}