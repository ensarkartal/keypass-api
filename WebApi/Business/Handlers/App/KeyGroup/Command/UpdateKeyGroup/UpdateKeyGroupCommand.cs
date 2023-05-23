using MediatR;
using WebApi.Domain.Abstract.App;
using WebApi.Entity.DataTransfers.App.KeyGroup;

namespace WebApi.Business.Handlers.App.KeyGroup.Command.UpdateKeyGroup;

public class UpdateKeyGroupCommand : IRequest
{
    public string? KeyGroupId { get; set; }
    public UpdateKeyGroupDto? UpdateKeyGroupDto { get; set; }
}

class UpdateKeyGroupCommandHandler : IRequestHandler<UpdateKeyGroupCommand>
{
    private IKeyGroupDal _keyGroupDal;

    public UpdateKeyGroupCommandHandler(IKeyGroupDal keyGroupDal)
    {
        _keyGroupDal = keyGroupDal;
    }

    public async Task Handle(UpdateKeyGroupCommand request, CancellationToken cancellationToken)
    {
        await _keyGroupDal.UpdateKeyGroyp(request.KeyGroupId, request.UpdateKeyGroupDto);
    }
}