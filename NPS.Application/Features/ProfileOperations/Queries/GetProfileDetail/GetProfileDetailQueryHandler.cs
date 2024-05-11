using AutoMapper;
using MediatR;
using NPS.Application.Features.UserOperations.Queries.GetProfileDetail;
using NPS.Application.Interfaces.Repositories;

namespace NPS.Application.Features.ProfileOperations.Queries.GetProfileDetail;

public class GetProfileDetailQueryHandler : IRequestHandler<GetProfileDetailQueryRequest, GetProfileDetailQueryResponse>
{
    private readonly IProfileRepository _ProfileRepository;
    private readonly IMapper _mapper;

    public GetProfileDetailQueryHandler(IProfileRepository ProfileRepository, IMapper mapper)
    {
        _ProfileRepository = ProfileRepository;
        _mapper = mapper;
    }

    public async Task<GetProfileDetailQueryResponse> Handle(GetProfileDetailQueryRequest request, CancellationToken cancellationToken)
    {
        var profile = await _ProfileRepository.GetAsync(b => b.Id == request.Id);

        GetProfileDetailQueryResponse mappedProfile = _mapper.Map<GetProfileDetailQueryResponse>(profile.First());
        return mappedProfile;
    }
}