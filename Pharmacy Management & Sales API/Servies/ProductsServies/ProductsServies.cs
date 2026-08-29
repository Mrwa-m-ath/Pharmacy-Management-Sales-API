using AutoMapper;
using Pharmacy_Management___Sales_API.DTO.DtoProduct;
using Pharmacy_Management___Sales_API.Model;
using Pharmacy_Management___Sales_API.Resposter;

namespace Pharmacy_Management___Sales_API.Servies.ProductsServies
{
    public class ProductsServies :IProductsServies  
   {

        private readonly ISResposter<Product> resposter;
        private readonly IMapper mapper;

        public ProductsServies(ISResposter<Product> resposter, IMapper mapper)
        {
            this.resposter = resposter;
            this.mapper = mapper;
        }
        public async Task<String> AddNewProduct(AddDtoProduct add)
        {
            var IsExist = await resposter.IsExist(a => a.NameProduct == add.NameProduct);
            if (IsExist != null)
            {
                throw new InvalidDataException("The Product Is Exist");
            }
            var AddProduct = mapper.Map<Product>(add);
            await resposter.addNewAysnc(AddProduct);
            await resposter.SaveAysnc();
            return "Success Add";
        }
        public async Task<String> RemoveAysnc(int id)
        {
            var IsExist = await resposter.IsExist(a => a.IdProduct == id);
            if (IsExist == null)
            {
                throw new InvalidDataException("The Product Is'n Exist");
            }
            await resposter.RemoveAysnc(IsExist);
            await resposter.SaveAysnc();
            return "Success Remove ";
        }
        public async Task<String> UpdateAysnc(UpdateProduct update,int id)
        {
            var IsExist = await resposter.IsExist(a => a.IdProduct == id);
            if (IsExist == null)
            {
                throw new InvalidDataException("The Product Is'n Exist");
            }
            var Update = mapper.Map(update, IsExist);
            await resposter.UpdateAysnc(Update) ;
            await resposter.SaveAysnc();
            return "Success Update";

        }
    }
}
