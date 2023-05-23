using Domain.Abstract.IDentity;
using Entity.DataTransfers.Identity.AppUser;
using MediatR;

namespace Business.Handlers.Identity.User.Queries.GetUsers;

public class GetUsersQuery : IRequest<List<GetAppUserDto>?>
{

}
public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<GetAppUserDto>?>
{
    private readonly IAppUserDal _userRepository;

    public GetUsersQueryHandler(IAppUserDal userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<GetAppUserDto>?> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetAppUsers();
    }
}