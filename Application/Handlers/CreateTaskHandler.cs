using CQRS.Practico.Application.DTOs;
using CQRS.Practico.Domain;
using CQRS.Practico.Infrastructure.Commands;
using CQRS.Practico.Infrastructure.Data;
using MediatR;

namespace CQRS.Practico.Application.Handlers
{
    public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, TaskItemDto>
    {
        private readonly AppDbContext _appDbContext;

        public async Task<TaskItemDto> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var taskItem = new TaskItem
            {
                Title = request.Title,
                Description = request.Description,
            };

            _appDbContext.Add(taskItem);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return new TaskItemDto
            {
                Title = request.Title,
                Description = request.Description,
            };

        }
    }
}