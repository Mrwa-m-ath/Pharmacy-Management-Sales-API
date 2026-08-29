using Pharmacy_Management___Sales_API.DTO.DtoProduct;
using Pharmacy_Management___Sales_API.Resposter;

namespace Pharmacy_Management___Sales_API.Servies.ProductsServies
{
    public interface IProductsServies
    {
        public Task<String> UpdateAysnc(UpdateProduct update, int id);
        public   Task<String> RemoveAysnc(int id);
        public   Task<String> AddNewProduct(AddDtoProduct add);
    }
}
