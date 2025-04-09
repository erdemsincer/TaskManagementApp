using System.Linq.Expressions;
using TaskManagementApp.BusinessLayer.Abstract;
using TaskManagementApp.DataAccessLayer.Abstract;

namespace TaskManagementApp.BusinessLayer.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : class
    {
        private readonly IGenericDal<T> _dal;

        public GenericManager(IGenericDal<T> dal)
        {
            _dal = dal;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dal.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dal.GetByIdAsync(id);
        }

        public async Task<List<T>> WhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dal.WhereAsync(predicate);
        }

        public async Task AddAsync(T entity)
        {
            await _dal.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            await _dal.UpdateAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            await _dal.DeleteAsync(entity);
        }

        public async Task<int> SaveAsync()
        {
            return await _dal.SaveAsync();
        }
    }
}
