using NPS.Application.Interfaces.Repositories;
using NPS.Domain.Entities;
using NPS.Infrastructure.Data;
using NPS.Infrastructure.Repositories.Base;

namespace NPS.Infrastructure.Repositories;

public class QuestionnaireRepository : BaseRepository<QuestionnaireEntity>, IQuestionnaireRepository
{
    public QuestionnaireRepository(ApplicationDbContext context) : base(context)
    {
    }
}