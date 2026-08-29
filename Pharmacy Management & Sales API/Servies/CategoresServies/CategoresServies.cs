using AutoMapper;
using Pharmacy_Management___Sales_API.DTO.DtoCategors;
using Pharmacy_Management___Sales_API.Model;
using Pharmacy_Management___Sales_API.Resposter;

namespace Pharmacy_Management___Sales_API.Servies.CategoresServies
{
    public class CategoresServies : ICategoresServies
    {
        private readonly ISResposter<Categpres> resposter;
        private readonly IMapper mapper;

        public CategoresServies(ISResposter<Categpres> resposter, IMapper mapper)
        {
            this.resposter = resposter;
            this.mapper = mapper;
        }
        public async Task<String> AddNewCategores(AddCategoresDto add)
        {
            var IsExist = await resposter.IsExist(s => s.NameCategpres == add.NameCategpres);
            if (IsExist != null)
            {  
                    throw new InvalidOperationException("The NameCategpres Is  Exist");
                }
                var NewCategores = mapper.Map<Categpres>(add);
                await resposter.addNewAysnc(NewCategores);
                await resposter.SaveAysnc();
                return "Success Add ";
            }
        public async Task<String> RemoveCatgores(int id)
        {
            var IsExist = await resposter.IsExist(s => s.IdCategpres == id);
            if (IsExist == null)
            {
                throw new InvalidOperationException("The  Categpres Is'n   Exist");
            }
            await resposter.RemoveAysnc(IsExist);
            await resposter.SaveAysnc();
            return "Success";
        }
        public async Task<String> UpdateCategores(UpDateCategores upDate,int id)
        {
            var IsExist = await resposter.IsExist(s => s.IdCategpres == id);
            if (IsExist == null)
            {
                throw new InvalidOperationException("The  Categpres Is'n  Exist");
            }
            var UpdateCategores = mapper.Map(upDate, IsExist);
            await resposter.UpdateAysnc(UpdateCategores);
            await resposter.SaveAysnc();
            return "Success";
        }
          
}}
