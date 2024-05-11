using AutoMapper;
using MediatR;
using NPS.Application.Features.UserQuestionnaireOperations.Queries.GetUserQuestionnaireDetail;
using NPS.Application.Features.UserQuestionnaireOperations.Rules;
using NPS.Application.Interfaces.Repositories;

namespace NPS.Application.Features.UserQuestionnaireOperations.Queries.GetUserQuestionnaireQuestionnaireDetail;

public class GetUserQuestionnaireQuestionnaireDetailQueryHandler : IRequestHandler<GetUserQuestionnaireDetailQueryRequest, GetUserQuestionnaireDetailQueryResponse>
{
    private readonly IUserQuestionnaireRepository _userQuestionnaireRepository;
    private readonly IRuleQuestionnaireRepository _ruleQuestionnaireRepository;
    private readonly IQuestionnaireRepository _questionnaireRepository;
    private readonly UserQuestionnaireBusinessRules _userQuestionnaireBusinessRules;
    private readonly IMapper _mapper;

    public GetUserQuestionnaireQuestionnaireDetailQueryHandler(
        IUserQuestionnaireRepository userQuestionnaireRepository,
        IRuleQuestionnaireRepository ruleQuestionnaireRepository,
        IQuestionnaireRepository questionnaireRepository,
        UserQuestionnaireBusinessRules userQuestionnaireBusinessRules,
        IMapper mapper
       )
    {
        _userQuestionnaireRepository = userQuestionnaireRepository;
        _ruleQuestionnaireRepository = ruleQuestionnaireRepository;
        _questionnaireRepository = questionnaireRepository;
        _userQuestionnaireBusinessRules = userQuestionnaireBusinessRules;
        _mapper = mapper;
    }

    public async Task<GetUserQuestionnaireDetailQueryResponse> Handle(GetUserQuestionnaireDetailQueryRequest request, CancellationToken cancellationToken)
    {
        var rules = await _ruleQuestionnaireRepository.GetAsync(x => x.QuestionnaireId == request.QuestionnaireId);
        var userQuestionnaires = await _userQuestionnaireRepository.GetAsync(x => x.QuestionnaireId == request.QuestionnaireId);

        if (userQuestionnaires?.Any() != true || rules?.Any() != true)
        {
            return new GetUserQuestionnaireDetailQueryResponse();
        }

        var ruleDictionary = rules.ToDictionary(r => (r.ScoreStart, r.ScoreEnd), r => r.Classification);
        int promoters = 0, detractors = 0, neutrals = 0;

        foreach (var response in userQuestionnaires)
        {
            var classification = ruleDictionary.FirstOrDefault(r => r.Key.ScoreStart <= response.Score && r.Key.ScoreEnd >= response.Score).Value;
            if (classification == "Promotores") promoters += response.Score;
            else if (classification == "Detractores") detractors += response.Score;
            else neutrals += response.Score;
        }

        double nps = CalculateNPS(promoters, detractors, userQuestionnaires.Count);

        return new GetUserQuestionnaireDetailQueryResponse
        {
            ClassificationDetail = new List<ClassificationDetailQueryResponse>
            {
                new() { Classification = "Promotores", Score = promoters },
                new() { Classification = "Detractores", Score = detractors },
                new() { Classification = "Neutrales", Score = neutrals },
            },
            TotalNps = nps
        };
    }

    private static double CalculateNPS(int promoters, int detractors, int totalResponses)
    {
        return (double)(promoters - detractors) / totalResponses * 100;
    }
}