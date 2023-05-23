using MediatR;
using WebApi.Domain.Abstract.IDentity;
using WebApi.Entity.DataTransfers.Identity.AppUser;

namespace WebApi.Business.Handlers.Identity.User.Command.UpdateUser;

public class UpdateAppUserCommand   : IRequest
{
    public string? UserId { get; set; }
    public UpdateAppUserDto? UpdateUserRequest { get; set; }


    public class UpdateUserCommandHandler : IRequestHandler<UpdateAppUserCommand>
    {
        private readonly IAppUserDal _userRepository;

        public UpdateUserCommandHandler(IAppUserDal userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(UpdateAppUserCommand request, CancellationToken cancellationToken)
        {
           await _userRepository.UpdateUSer(request.UserId, request.UpdateUserRequest);
        }
    }
}