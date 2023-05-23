using MediatR;
using WebApi.Domain.Abstract.App;
using WebApi.Entity.DataTransfers.App.KeyGroup;

namespace WebApi.Business.Handlers.App.KeyGroup.Query.GetKeyGroup;

public class GetKeyGroupQuery : IRequest<GetKeyGroupDto>
{
    public string? KeyGroupId { get; set; }
}

class GetKeyGroupQueryHandler : IRequestHandler<GetKeyGroupQuery, GetKeyGroupDto>
{
    private IKeyGroupDal _keyGroupDal;

    public GetKeyGroupQueryHandler(IKeyGroupDal keyGroupDal)
    {
        _keyGroupDal = keyGroupDal;
    }

    public async Task<GetKeyGroupDto> Handle(GetKeyGroupQuery request, CancellationToken cancellationToken)
    {
        var result = await _keyGroupDal.GetKeyGroup(request.KeyGroupId);
        return result;
    }
}