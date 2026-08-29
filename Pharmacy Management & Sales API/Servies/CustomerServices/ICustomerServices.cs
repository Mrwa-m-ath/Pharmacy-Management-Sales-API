using Pharmacy_Management___Sales_API.DTO.CustomerDto;

namespace Pharmacy_Management___Sales_API.Servies.CustomerServices
{
    public interface ICustomerServices
    {
        public Task<String> AddCustomerDto(AddCustomerDto add);
        public    Task<String> UpdateCustomerDto(UpdateCustomerDto upDate, int id);
        public Task<String> RemoveCustomer(int id);
    }
}
