using CQRS.Practico.Application.DTOs;
using MediatR;

namespace CQRS.Practico.Infrastructure.Queries
{
    public record GetAllTaskQuery : IRequest<IEnumerable<TaskItemDto>>;
}
