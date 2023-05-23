using Domain.Abstract.App;
using Entity.DataTransfers.App.KeyGroup;
using MediatR;

namespace Business.Handlers.App.KeyGroup.Query.GetKeyGroups;

public class GetKeyGroupsQuery : IRequest<List<GetKeyGroupDto>>
{

}

class GetKeyGroupsQueryHandler : IRequestHandler<GetKeyGroupsQuery, List<GetKeyGroupDto>>
{
    private IKeyGroupDal _keyGroupDal;

    public GetKeyGroupsQueryHandler(IKeyGroupDal keyGroupDal)
    {
        _keyGroupDal = keyGroupDal;
    }

    public async Task<List<GetKeyGroupDto>> Handle(GetKeyGroupsQuery request, CancellationToken cancellationToken)
    {
        var result = await _keyGroupDal.GetKeyGroups();
        return result;
    }
}