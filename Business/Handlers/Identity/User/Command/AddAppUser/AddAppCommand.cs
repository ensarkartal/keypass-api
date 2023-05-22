using Domain.Abstract.IDentity;
using Entity.DataTransfers.Identity.AppUser;
using MediatR;

namespace Business.Handlers.Identity.User.Command.AddAppUser;

public class AddAppCommand :  IRequest<string>
{
    public AddAppUserDto? CreateUserRequest { get; set; }
}

class CreateUserCommandHandler : IRequestHandler<AddAppCommand, string>
{
    private IAppUserDal _userDal;



    public CreateUserCommandHandler(IAppUserDal userDal)
    {
        _userDal = userDal;
    }

    public async Task<string> Handle(AddAppCommand request, CancellationToken cancellationToken)
    {
       var result = await _userDal.AddUSer(request.CreateUserRequest);
       return result;
    }
}