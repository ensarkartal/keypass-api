using Domain.Abstract.App;
using MediatR;

namespace Business.Handlers.App.KeyGroup.Command.DeleteKeyGroup;

public class DeleteKeyGroupCommand : IRequest
{
    public string? KeyGroupId { get; set; }
}

class DeleteKeyGroupCommandHandler : IRequestHandler<DeleteKeyGroupCommand>
{
    private IKeyGroupDal _keyGroupDal;

    public DeleteKeyGroupCommandHandler(IKeyGroupDal keyGroupDal)
    {
        _keyGroupDal = keyGroupDal;
    }

    public async Task Handle(DeleteKeyGroupCommand request, CancellationToken cancellationToken)
    {
        await _keyGroupDal.DeleteKeyGroup(request.KeyGroupId);
    }
}