using Domain.Abstract.App;
using Entity.DataTransfers.App.KeyGroup;
using MediatR;

namespace Business.Handlers.App.KeyGroup.Command.AddKeyGroup;

public class AddKeyGroupCommand : IRequest<string>
{
    public AddKeyGroupDto? AddKeyGroupDto { get; set; }
}

class AddKeyGroupCommandHandler : IRequestHandler<AddKeyGroupCommand, string>
{
    private IKeyGroupDal _keyGroupDal;

    public AddKeyGroupCommandHandler(IKeyGroupDal keyGroupDal)
    {
        _keyGroupDal = keyGroupDal;
    }

    public async Task<string> Handle(AddKeyGroupCommand request, CancellationToken cancellationToken)
    {
        var result = await _keyGroupDal.AddKeyGroup(request.AddKeyGroupDto);
        return result;
    }
}