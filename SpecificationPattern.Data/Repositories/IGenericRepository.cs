using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Specifications;
using SpecificationPattern.Core.Entities;

namespace Data.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(ISpecification<T> specification);
        Task<List<T>> GetAllAsync(ISpecification<T> specification);
        Task<T> CreateAsync(T entity);
        Task<T> RemoveAsync(T entity);
    }
}


