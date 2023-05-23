using MediatR;
using WebApi.Domain.Abstract.IDentity;
using WebApi.Entity.DataTransfers.Identity.AppUser;

namespace WebApi.Business.Handlers.Identity.User.Queries.GetUser;

public class GetUserQuery : IRequest<GetAppUserDto?>
{
    public string? UserId { get; set; }

    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetAppUserDto?>
    {
        private readonly IAppUserDal _userRepository;

        public GetUserQueryHandler(IAppUserDal userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<GetAppUserDto?> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
           return await _userRepository.GetAppUser(request.UserId);
        }
    }
}