using AutoMapper;
using NPS.Application.Features.QuestionnaireOperations.Queries.GetQuestionnaires;
using NPS.Application.Features.RuleOperations.Queries.GetRuleQuestionnaireDetail;
using NPS.Application.Features.UserOperations.Commands;
using NPS.Application.Features.UserOperations.Queries.GetProfileDetail;
using NPS.Application.Features.UserOperations.Queries.GetUserDetail;
using NPS.Application.Features.UserOperations.Queries.GetUsers;
using NPS.Domain.Entities;

namespace NPS.Application.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // Users
        CreateMap<UserEntity, CreateUserCommandResponse>().ReverseMap();
        CreateMap<UserEntity, CreateUserCommandRequest>().ReverseMap();
        CreateMap<UserEntity, GetUsersQueryResponse>().ReverseMap();
        CreateMap<UserEntity, GetUserDetailQueryResponse>().ReverseMap();

        // Profile
        CreateMap<ProfileEntity, GetProfileDetailQueryResponse>().ReverseMap();

        // Questionnaire
        CreateMap<QuestionnaireEntity, GetQuestionnairesQueryResponse>().ReverseMap();

        // RuleQuestionnaire
        CreateMap<RuleQuestionnaireEntity, GetRuleQuestionnaireDetailQueryResponse>().ReverseMap();
    }
}