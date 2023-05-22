using Domain.Abstract.App;
using Entity.DataTransfers.App.KeyGroup;
using MediatR;

namespace Business.Handlers.App.KeyGroup.Command.UpdateKeyGroup;

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