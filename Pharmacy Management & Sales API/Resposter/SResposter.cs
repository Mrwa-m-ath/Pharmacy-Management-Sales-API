using Microsoft.EntityFrameworkCore;
using Pharmacy_Management___Sales_API.Configration;
using System.Linq.Expressions;

namespace Pharmacy_Management___Sales_API.Resposter
{
    public class SResposter<T> : ISResposter<T>
        where T : class
    {
        private readonly AppDbContext app1;

        public SResposter(AppDbContext app1)
        {
            this.app1 = app1;
        }
        public   async Task   addNewAysnc(T t)
        {
                  await  app1.Set<T>().AddAsync(t);
        }
        public async Task RemoveAysnc(T t)
        {
             app1.Set<T>().Remove(t);
        }
        public async Task UpdateAysnc(T t)
        {
              app1.Set<T>().Update(t);
        }
        public async Task<T?> IsExist(Expression<Func<T,bool>> W)
        {
            return await app1.Set<T>().FirstOrDefaultAsync(W
                );
        }
        public async Task SaveAysnc()
        {
            await app1.SaveChangesAsync();
        }
        public async Task<List<T>> GetAllAsync( )
        {
        return await  app1.Set<T>().ToListAsync();
        }
    }
}
 