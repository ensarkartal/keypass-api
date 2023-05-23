using MediatR;
using WebApi.Domain.Abstract.IDentity;
using WebApi.Entity.DataTransfers.Identity.AppUser;

namespace WebApi.Business.Handlers.Identity.User.Queries.GetUsers;

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