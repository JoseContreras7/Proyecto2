using MediatR;
using Proyecto2.Model;

namespace Proyecto2.Mediator
{
    public class CreateUserCommand : IRequest<User>
    {
        public User User { get; set; }
    }
}
