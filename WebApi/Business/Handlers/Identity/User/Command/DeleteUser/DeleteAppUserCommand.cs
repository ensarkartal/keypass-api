using MediatR;
using WebApi.Domain.Abstract.IDentity;

namespace WebApi.Business.Handlers.Identity.User.Command.DeleteUser;

public class DeleteAppUserCommand : IRequest
{
    public string? UserId { get; set; }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteAppUserCommand>
    {
        private readonly IAppUserDal _userRepository;

        public DeleteUserCommandHandler(IAppUserDal userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(DeleteAppUserCommand request, CancellationToken cancellationToken)
        {
           await _userRepository.DeleteUSer(request.UserId);
        }
    }
}