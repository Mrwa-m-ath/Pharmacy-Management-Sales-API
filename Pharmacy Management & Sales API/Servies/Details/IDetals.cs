namespace Pharmacy_Management___Sales_API.Servies.Details
{
    public interface IDetals
    {
        public Task<int> NewStock(int sub);
        public double Tota();
        public double SubTotal();
    }
}
