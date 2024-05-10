using NPS.Domain.Entities.Common;

namespace NPS.Application.Interfaces.Repositories.Base;

public interface IRepository<T> where T : BaseEntity
{
    IQueryable<T> Table { get; }
    IQueryable<T> TableNoTracking { get; }
}