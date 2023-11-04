using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionTecnica.Negocio.dbContext.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> getById(int id);
        Task<bool> Insert(T model);
        Task<bool> Update(T model);
        Task<bool> Delete(int id);
        
    }
}
