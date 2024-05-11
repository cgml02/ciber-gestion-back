using NPS.Application.Features.UserQuestionnaireOperations.Commands;
using NPS.Application.Interfaces.Repositories;

namespace NPS.Application.Features.UserQuestionnaireOperations.Rules;

public class UserQuestionnaireBusinessRules
{
    private readonly IUserQuestionnaireRepository _userQuestionnaireRepository;

    public UserQuestionnaireBusinessRules(IUserQuestionnaireRepository userQuestionnaireRepository)
    {
        _userQuestionnaireRepository = userQuestionnaireRepository;
    }

    public async Task QuestionnaireCanNotBeDuplicatedWhenInserted(CreateUserQuestionnaireCommandRequest request)
    {
        var result = await _userQuestionnaireRepository.GetAsync(b => b.UserId == request.UserId && b.QuestionnaireId == request.QuestionnaireId);

        if (result != null && result.Count > 0) throw new Exception("Ya existe el cuestionario asociado al usuario");
    }
}