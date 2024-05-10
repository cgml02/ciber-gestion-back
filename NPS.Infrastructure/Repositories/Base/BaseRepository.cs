using Microsoft.EntityFrameworkCore;
using NPS.Application.Interfaces.Repositories.Base;
using NPS.Domain.Entities.Common;
using NPS.Infrastructure.Data;
using System.Linq.Expressions;

namespace NPS.Infrastructure.Repositories.Base;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    #region ctor

    protected readonly ApplicationDbContext _context;

    public BaseRepository(ApplicationDbContext context)
         => _context = context ?? throw new ArgumentNullException(nameof(context));

    #endregion ctor

    #region IRepository(Tables)

    public IQueryable<T> Table => _context.Set<T>();
    public IQueryable<T> TableNoTracking => _context.Set<T>().AsNoTracking();

    #endregion IRepository(Tables)

    #region Insert

    public async Task<T> AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        return entity;
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
         => await _context.Set<T>().AddRangeAsync(entities);

    #endregion Insert

    #region Update

    public void Update(T entity)
         => _context.Entry(entity).State = EntityState.Modified;

    public void UpdateRange(IEnumerable<T> entities)
         => _context.Entry(entities).State = EntityState.Modified;

    #endregion Update

    #region Delete

    public void Remove(T entity)
         => _context.Entry(entity).State = EntityState.Deleted;

    public void RemoveRange(IEnumerable<T> entities)
         => _context.Entry(entities).State = EntityState.Deleted;

    #endregion Delete

    #region Save

    public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

    #endregion Save

    #region Select

    public async Task<IReadOnlyList<T>> GetAllAsync() => await TableNoTracking.ToListAsync();

    public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate) => await TableNoTracking.Where(predicate).ToListAsync();

    public async Task<T> GetFirstAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = Table;

        if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

        if (predicate != null) query = query.Where(predicate);

        return await query.AsNoTracking().FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = TableNoTracking;

        if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

        if (predicate != null) query = query.Where(predicate);

        return await query.AsNoTracking().ToListAsync();
    }

    public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null,
                                                      Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                                      string? includeString = null, bool disableTracking = true)
    {
        IQueryable<T> query = TableNoTracking;
        if (disableTracking) query = query.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

        if (predicate != null) query = query.Where(predicate);

        if (orderBy != null)
            return await orderBy(query).ToListAsync();
        return await query.ToListAsync();
    }

    public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, List<Expression<Func<T, object>>>? includes = null, bool disableTracking = true)
    {
        IQueryable<T> query = TableNoTracking;
        if (disableTracking) query = query.AsNoTracking();

        if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

        if (predicate != null) query = query.Where(predicate);

        if (orderBy != null)
            return await orderBy(query).ToListAsync();
        return await query.ToListAsync();
    }

    public virtual async Task<T> GetByIdAsync(string id) => await _context.Set<T>().FindAsync(id);

    public virtual async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

    public virtual async Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<string> ids) => await _context.Set<IEnumerable<T>>().FindAsync(ids);

    public virtual async Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<int> ids) => await _context.Set<IEnumerable<T>>().FindAsync(ids);

    public virtual async Task<int> CountAsync() => await _context.Set<T>().CountAsync();

    public virtual async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null) => await _context.Set<T>().CountAsync(predicate);

    public async Task<T> GetForMultipleKeys(params object[] keyValues) => await _context.Set<T>().FindAsync(keyValues);

    #endregion Select
}