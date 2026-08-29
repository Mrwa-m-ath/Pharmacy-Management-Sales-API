using Pharmacy_Management___Sales_API.Configration;
using Pharmacy_Management___Sales_API.Model;
using Pharmacy_Management___Sales_API.Resposter;

namespace Pharmacy_Management___Sales_API.Servies.Details
{
    public class Detals: IDetals
    {
        private readonly Product product;
        private readonly Detalis Detalis;
        private readonly ISResposter<Detalis> resposter;

        private readonly ISResposter<Product> presposter;

        public Detals(Product product, Detalis detalis, ISResposter<Detalis> resposter, ISResposter<Product> presposter)
        {
            this.product = product;
            Detalis = detalis;
            this.resposter = resposter;
            this.presposter = presposter;
        }

        public    double  SubTotal()
        {
            double suP = product.Quinte * product.Cost;
            Detalis.SubTotal = suP;
                resposter.SaveAysnc();
            return suP;


        }
        public async Task<int> NewStock(int sub)
        { 
            if (sub >product.Stock)
            {
                throw new InvalidDataException("is'n Exist");
            }
            var NewSto = product.Stock - sub;
            product.Stock = NewSto;
            
            await     presposter.SaveAysnc();
            return NewSto;

        }
        public double Tota()
        {
             
            return SubTotal();
        }
    }
}
