using AutoMapper;
using Pharmacy_Management___Sales_API.DTO.CustomerDto;
using Pharmacy_Management___Sales_API.DTO.DtoCategors;
using Pharmacy_Management___Sales_API.DTO.DtoUsers;
using Pharmacy_Management___Sales_API.DTO.SaleDto;
using Pharmacy_Management___Sales_API.Model;

namespace Pharmacy_Management___Sales_API.Configration
{
    public class Mappers : Profile
    {
        private readonly IMapper mapper;

        public Mappers()
        {
            CreateMap<User, UserDtoCreatAccount>().ReverseMap();
            CreateMap<Categpres, AddCategoresDto>().ReverseMap();
            CreateMap<User, UserDtoCreatAccount>().ReverseMap();
            CreateMap<Categpres, UpDateCategores>().ReverseMap();
            CreateMap<Customer, AddCustomerDto>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDto>().ReverseMap();
            CreateMap<Sales, AddSaleDto>().ReverseMap();
            CreateMap<Sales, UpdateSaleDto>().ReverseMap();
        }
    }
}
