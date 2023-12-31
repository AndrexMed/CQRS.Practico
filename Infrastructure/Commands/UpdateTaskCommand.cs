using CQRS.Practico.Application.DTOs;
using MediatR;

namespace CQRS.Practico.Infrastructure.Commands
{
    public record UpdateTaskCommand(int Id,
                                    string Title,
                                    string Description,
                                    bool IsComplete) : IRequest<TaskItemDto>;
}