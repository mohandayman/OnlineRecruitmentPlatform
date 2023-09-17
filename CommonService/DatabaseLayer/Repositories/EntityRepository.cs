using CommonService.DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.DatabaseLayer.Repositories
{
    public class EntityRepository<T> : IEntityRepository<T> where T : class, IEntity
    {
        public DbContext SystemContext { get; }

        public EntityRepository( DbContext systemContext)
        {
            SystemContext = systemContext;
        }
        public async Task<List<T>> GetAllAsync()
        {
            var Enteties = await SystemContext.Set<T>().AsNoTracking().ToListAsync<T>();
            return Enteties;


             
        }
        public async Task<T> GetById(int id)
        {
            return await SystemContext.Set<T>().FirstOrDefaultAsync(I => I.ID == id);
        }

        public async Task<bool> Add(T Element)
        {
            EntityEntry<T>  Entity = await SystemContext.Set<T>().AddAsync(Element);
            SystemContext.SaveChanges();
            return Entity.State == EntityState.Added;
        }

        public async Task<bool> Update(T UpdatedValue)
        {
            T Entity = await GetById(UpdatedValue.ID);
            Type type = typeof(T);
            if (Entity != null)
            {
                foreach (PropertyInfo property in type.GetProperties())
                {
                    // Get the corresponding property value from UpdatedValue
                    PropertyInfo updatedProperty = type.GetProperty(property.Name);
                    object updatedPropertyValue = updatedProperty.GetValue(UpdatedValue);

                    // Set the property value in Entity
                    property.SetValue(Entity, updatedPropertyValue);
                }
                SystemContext.SaveChanges();
                return true;

            }
            return false;
        }
        public async Task<bool> Delete(int ID)
        {
            var DeletedElement = await GetById(ID);
            if (DeletedElement != null)
            {
                var DeleteResult = SystemContext.Set<T>().Remove(DeletedElement);
                if (DeleteResult.State == EntityState.Deleted)
                {
                    SystemContext.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            return false;
        }

      

        public async Task<List<T>> Filter(T FilteringAttrebutes)
        {
            var dbSet = SystemContext.Set<T>();

            // Create an initial query that includes all entities
            IQueryable<T> query = dbSet;


            Type type = typeof(T);

            foreach (PropertyInfo property in type.GetProperties())
            {
                var propertyValue = property.GetValue(FilteringAttrebutes);

                if (propertyValue != null && property.Name != "ID")
                {
                    if(!(propertyValue.GetType() is string) && string.IsNullOrEmpty((string)propertyValue) )
                    {
                    query = query.Where(entity => property.GetValue(entity).Equals(propertyValue));
                    }
                }
            }
            return await query.ToListAsync();

        }
    }
}
