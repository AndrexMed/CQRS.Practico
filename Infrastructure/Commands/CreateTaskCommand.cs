using CQRS.Practico.Application.DTOs;
using MediatR;

namespace CQRS.Practico.Infrastructure.Commands
{
    public record CreateTaskCommand(string Title,
                                    string Description) : IRequest<TaskItemDto>;
}
