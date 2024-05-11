using NPS.Application.Interfaces.Repositories;
using NPS.Domain.Entities;
using NPS.Infrastructure.Data;
using NPS.Infrastructure.Repositories.Base;

namespace NPS.Infrastructure.Repositories;

public class RuleQuestionnaireRepository : BaseRepository<RuleQuestionnaireEntity>, IRuleQuestionnaireRepository
{
    public RuleQuestionnaireRepository(ApplicationDbContext context) : base(context)
    {
    }
}