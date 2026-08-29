using Pharmacy_Management___Sales_API.DTO.DtoCategors;

namespace Pharmacy_Management___Sales_API.Servies.CategoresServies
{
    public interface ICategoresServies
    {
        public Task<String> AddNewCategores(AddCategoresDto add);
        public   Task<String> RemoveCatgores(int id); 
        public Task<String> UpdateCategores(UpDateCategores upDate, int id);
    }
}
