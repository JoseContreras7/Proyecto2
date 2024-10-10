using MediatR;
using Proyecto2.Model;
using Proyecto2.Repository.Interface;

namespace Proyecto2.Mediator
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUserRepository<User> _UserRepository;

        public CreateUserCommandHandler(IUserRepository<User> userRepository)
        {
            _UserRepository = userRepository;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _UserRepository.CreateAsync(request.User);

            return request.User;
        }
    }
}
