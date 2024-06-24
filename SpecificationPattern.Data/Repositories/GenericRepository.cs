
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Specifications;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using SpecificationPattern.Core.Entities;
using SpecificationPattern.Data;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    // Changes
    public async Task<T> GetByIdAsync(ISpecification<T> specification)
    {
        var query =  ApplySpecification(specification);
        return await query.FirstOrDefaultAsync();
    }

    public async Task<T>CreateAsync( T entity)
    {
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T>RemoveAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }


    //Changes
    public async Task<List<T>> GetAllAsync(ISpecification<T> specification)
    {
        IQueryable<T> query = ApplySpecification(specification);       
        return await query.ToListAsync();
    }



    private IQueryable<T> ApplySpecification(ISpecification<T> specification)
    {
        IQueryable<T> query = _context.Set<T>().AsQueryable();

        // Apply criteria
        if (specification.Criteria != null)
        {
            query = query.Where(specification.Criteria);
        }

        if (specification.OrderBy != null)
        {
            query = ApplyOrder(query, specification.OrderBy);
        }
        else if (specification.OrderByDescending != null)
        {
            query = ApplyOrder(query, specification.OrderByDescending, true);
        }
        // Apply includes
        foreach (var include in specification.Includes)
        {
            query = query.Include(include);

        }

        if (specification.IsPagingEnabled && specification.Skip.HasValue && specification.Take.HasValue)
        {
            query = query.Skip(specification.Skip.Value).Take(specification.Take.Value);
        }

        return query;
    }

    private IQueryable<T> ApplyOrder(IQueryable<T> query, Expression<Func<T, object>> orderByExpression, bool descending = false)
    {
        if (descending)
        {
            return query.OrderByDescending(orderByExpression);
        }
        else
        {
            return query.OrderBy(orderByExpression);
        }
    }


}

