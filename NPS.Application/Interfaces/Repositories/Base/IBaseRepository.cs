using NPS.Domain.Entities.Common;
using System.Linq.Expressions;

namespace NPS.Application.Interfaces.Repositories.Base;

public interface IBaseRepository<T> : IRepository<T> where T : BaseEntity
{
    #region Insert

    Task<T> AddAsync(T entity);

    Task AddRangeAsync(IEnumerable<T> entities);

    #endregion Insert

    #region Update

    void Update(T entity);

    void UpdateRange(IEnumerable<T> entities);

    #endregion Update

    #region Delete

    void Remove(T entity);

    void RemoveRange(IEnumerable<T> entities);

    #endregion Delete

    #region SaveAsync

    Task<int> SaveAsync();

    #endregion SaveAsync

    #region Select

    Task<IReadOnlyList<T>> GetAllAsync();

    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null); // GetAsync

    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null,
                                         params Expression<Func<T, object>>[] includes);

    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null,
                                         Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                         string? includeString = null,
                                         bool disableTracking = true);

    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                        List<Expression<Func<T, object>>>? includes = null,
                                        bool disableTracking = true);

    Task<T> GetFirstAsync(Expression<Func<T, bool>>? predicate = null,
                                       params Expression<Func<T, object>>[] includes);

    Task<T> GetByIdAsync(string id);

    Task<T> GetByIdAsync(int id);

    Task<T> GetForMultipleKeys(params object[] keyValues);

    Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<string> ids);

    Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<int> ids);

    Task<int> CountAsync();

    Task<int> CountAsync(Expression<Func<T, bool>> predicate);

    #endregion Select
}