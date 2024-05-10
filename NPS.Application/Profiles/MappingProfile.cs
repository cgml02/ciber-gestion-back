using AutoMapper;
using NPS.Application.Features.UserOperations.Commands;
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
    }
}
