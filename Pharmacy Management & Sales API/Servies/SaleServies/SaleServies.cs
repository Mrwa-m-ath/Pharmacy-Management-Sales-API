using AutoMapper;
using Pharmacy_Management___Sales_API.Configration;
using Pharmacy_Management___Sales_API.DTO.SaleDto;
using Pharmacy_Management___Sales_API.Model;
using Pharmacy_Management___Sales_API.Resposter;

namespace Pharmacy_Management___Sales_API.Servies.SaleServies
{
    public class SaleServies    :  ISaleServies 
    {
        private readonly ISResposter<Sales> resposter;
        private readonly ISResposter<Customer> Cresposter;
        private readonly   IMapper mappers;

        private readonly ISResposter<Product> Presposter;

        public SaleServies(ISResposter<Sales> resposter, ISResposter<Customer> cresposter, IMapper mappers, ISResposter<Product> presposter)
        {
            this.resposter = resposter;
            Cresposter = cresposter;
            this.mappers = mappers;
            Presposter = presposter;
        }

        public async Task<string> AddNewSale(AddSaleDto Add)
        {
            var product = await Presposter.IsExist(
                s => s.IdProduct == Add.IdProduct);

            if (product == null)
            {
                throw new InvalidDataException("Product doesn't exist");
            }

            var customer = await Cresposter.IsExist(
                s => s.idCustomer == Add.idCustomer);

            if (customer == null)
            {
                throw new InvalidDataException("Customer doesn't exist");
            }

            if (Add.Quantity <= 0)
            {
                throw new InvalidDataException("Quantity must be greater than zero");
            }

            if (product.Stock < Add.Quantity)
            {
                throw new InvalidDataException("Insufficient stock");
            }

            var total = product.Cost * Add.Quantity;

            var newSale = new Sales
            {
                IdProduct = Add.IdProduct,
                idCustomer = Add.idCustomer,
                Quantity = Add.Quantity,
                Cost = product.Cost,
                Total = total,
                PaymentMethods = Add.PaymentMethods
            };

            product.Stock -= Add.Quantity;

            await resposter.addNewAysnc(newSale);
            await resposter.SaveAysnc();

            return "Success Add";
        }
        public async Task<string> UpdateAsync(UpdateSaleDto dto, int id)
        {
            var IsExist = await resposter.IsExist(s => s.idSales == id);

            if (IsExist == null)
            {
                throw new InvalidDataException("Is'n Exist");
            }
            var Upmap = mappers.Map(dto, IsExist );
            await resposter.UpdateAysnc(Upmap);
            await resposter.SaveAysnc();
            return "Success";
        }
        public async Task<string> Remove( int id)
        {
            var IsExist = await resposter.IsExist(s => s.idSales == id);

            if (IsExist == null)
            {
                throw new InvalidDataException("Is'n Exist");
            }
            
            await resposter.RemoveAysnc(IsExist);
            await resposter.SaveAysnc();
            return "Success";
        }
        public async Task<List<GetAllDate>> GetAllSale()
        {
            var GetAll =await resposter.GetAllAsync();
            return GetAll.Select(s => new GetAllDate
            {
                
                Cost=s.Cost,
                idCustomer=s.idCustomer,
                PaymentMethods=s.PaymentMethods,
                Total=s.Total,
                IdProduct=s.IdProduct,
                Quantity=s.Quantity
               
            }).ToList();
        }
    }
}
