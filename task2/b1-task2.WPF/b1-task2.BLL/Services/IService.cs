using b1_task2.BLL.Models;

namespace b1_task2.BLL.Services
{
    public interface IService<TEntity> where TEntity : BaseEntityDTO
    {
        TEntity GetById(Guid id);   
        public IEnumerable<TEntity> GetAll();
        void Add(TEntity dto);
        //public void Update(int id, TEntity dto);
        //public void Delete(int id);
    }
}
