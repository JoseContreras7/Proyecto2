using MediatR;
using Proyecto2.Model;

namespace Proyecto2.Mediator
{
    public class UpdateUserCommand : IRequest<User>
    {
        public User User { get; set; }
    }
}
