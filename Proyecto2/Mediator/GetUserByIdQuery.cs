using MediatR;
using Proyecto2.Model;

namespace Proyecto2.Mediator
{
    public record GetUserByIdQuery(int Id) : IRequest<User>;
}
