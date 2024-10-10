using MediatR;
using Proyecto2.Model;
using Proyecto2.Repository.Interface;

namespace Proyecto2.Mediator
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUserRepository<User> _UserRepository;

        public GetUserByIdHandler(IUserRepository<User> userRepository)
        {
            _UserRepository = userRepository;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _UserRepository.GetUserByIdAsync(request.Id);
        }
    }
}
