using NPS.Application.Interfaces.Repositories;
using NPS.Domain.Entities;
using NPS.Infrastructure.Data;
using NPS.Infrastructure.Repositories.Base;

namespace NPS.Infrastructure.Repositories;

public class UserQuestionnaireRepository : BaseRepository<UserQuestionnaireEntity>, IUserQuestionnaireRepository
{
    public UserQuestionnaireRepository(ApplicationDbContext context) : base(context)
    {
    }
}