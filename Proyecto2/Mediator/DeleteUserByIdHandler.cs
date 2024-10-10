using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Proyecto2.Model;
using Proyecto2.Repository.Interface;

namespace Proyecto2.Mediator
{
    public class DeleteUserByIdHandler : IRequestHandler<DeleteUserByIdQuery, User>
    {
        private readonly IUserRepository<User> _UserRepository;

        public DeleteUserByIdHandler(IUserRepository<User> userRepository)
        {
            _UserRepository = userRepository;
        }

        public async Task<User> Handle(DeleteUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _UserRepository.GetUserByIdAsync(request.Id);
            if (user == null)
            {
                throw new Exception($"Product with Id {request.Id} not found.");
            }

             await _UserRepository.DeleteAsync(request.Id);

            return user;
        }
    }
}
