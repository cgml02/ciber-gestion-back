using NPS.Application.Interfaces.Repositories;
using NPS.Domain.Entities;
using NPS.Infrastructure.Data;
using NPS.Infrastructure.Repositories.Base;

namespace NPS.Infrastructure.Repositories;

public class UserRepository : BaseRepository<UserEntity>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }
}