using MediatR;
using Proyecto2.Model;

namespace Proyecto2.Mediator
{
    public record DeleteUserByIdQuery(int Id) : IRequest<User>;
}
