using AutoMapper;
using Pharmacy_Management___Sales_API.DTO.CustomerDto;
using Pharmacy_Management___Sales_API.DTO.DtoCategors;
using Pharmacy_Management___Sales_API.Model;
using Pharmacy_Management___Sales_API.Resposter;

namespace Pharmacy_Management___Sales_API.Servies.CustomerServices
{
    public class CustomerServices: ICustomerServices
    {
        private readonly ISResposter<Customer> resposter;
        private readonly IMapper mapper;

        public CustomerServices(ISResposter<Customer> resposter, IMapper mapper)
        {
            this.resposter = resposter;
            this.mapper = mapper;
        }
        public async Task<String> AddCustomerDto(AddCustomerDto add)
        {
            var IsExist = await resposter.IsExist(s => s.NameCustomer == add.NameCustomer);
            if (IsExist != null)
            {
                throw new InvalidOperationException("The NameCustomer Is  Exist");
            }
            var NameCustomer = mapper.Map<Customer>(add);
            await resposter.addNewAysnc(NameCustomer);
            await resposter.SaveAysnc();
            return "Success Add ";
        }
        public async Task<String> RemoveCustomer(int id)
        {
            var IsExist = await resposter.IsExist(s => s.idCustomer == id);
            if (IsExist == null)
            {
                throw new InvalidOperationException("The   Customer Is'n   Exist");
            }
            await resposter.RemoveAysnc(IsExist);
            await resposter.SaveAysnc();
            return "Success";
        }
        public async Task<String> UpdateCustomerDto(UpdateCustomerDto upDate, int id)
        {
            var IsExist = await resposter.IsExist(s => s.idCustomer == id);
            if (IsExist == null)
            {
                throw new InvalidOperationException("The  Customer Is'n  Exist");
            }
            var UpdateCustomerDto = mapper.Map(upDate, IsExist);
            await resposter.UpdateAysnc(UpdateCustomerDto);
            await resposter.SaveAysnc();
            return "Success";
        }
          
    }
}
