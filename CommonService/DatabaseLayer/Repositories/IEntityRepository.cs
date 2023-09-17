using CommonService.DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.DatabaseLayer.Repositories
{
    public interface IEntityRepository<T>where T : IEntity
    {
        public Task<List<T>> GetAllAsync();
        public Task<T> GetById(int id);
        public Task<List<T>> Filter(T FilteringAttrebutes);
        public Task<bool> Add(T Element);
        public Task<bool> Update(T UpdatedValue);
        public Task<bool> Delete(int ID );
       
    }
}
