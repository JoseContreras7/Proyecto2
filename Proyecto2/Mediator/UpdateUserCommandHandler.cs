using MediatR;
using Proyecto2.Model;
using Proyecto2.Repository.Interface;

namespace Proyecto2.Mediator
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUserRepository<User> _UserRepository;

        public UpdateUserCommandHandler(IUserRepository<User> userRepository)
        {
            _UserRepository = userRepository;
        }

        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await _UserRepository.UpdateAsync(request.User);

            return request.User;
        }
    }
}
