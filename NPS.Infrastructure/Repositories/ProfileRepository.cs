using NPS.Application.Interfaces.Repositories;
using NPS.Domain.Entities;
using NPS.Infrastructure.Data;
using NPS.Infrastructure.Repositories.Base;

namespace NPS.Infrastructure.Repositories;

public class ProfileRepository : BaseRepository<ProfileEntity>, IProfileRepository
{
    public ProfileRepository(ApplicationDbContext context) : base(context)
    {
    }
}