using System.Linq.Expressions;

namespace Pharmacy_Management___Sales_API.Resposter
{
    public interface ISResposter   <T> where T :class
    {
        public Task<T?> IsExist(Expression<Func<T, bool>> W);
        public Task RemoveAysnc(T t);
        public Task addNewAysnc(T t); 
        public Task UpdateAysnc(T t);
        public   Task SaveAysnc();
        public Task<List<T>> GetAllAsync();
    }
}
