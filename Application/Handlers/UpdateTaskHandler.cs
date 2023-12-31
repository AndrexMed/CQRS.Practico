using CQRS.Practico.Application.DTOs;
using CQRS.Practico.Infrastructure.Commands;
using CQRS.Practico.Infrastructure.Data;
using MediatR;

namespace CQRS.Practico.Application.Handlers
{
    public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, TaskItemDto>
    {
        private readonly AppDbContext _context;

        public UpdateTaskHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TaskItemDto> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var taskItem = await _context.TaskItems.FindAsync(
                new object[] { request.Id }, cancellationToken);

            if (taskItem == null)
            {
                return null!;
            }

            taskItem.Title = request.Title;
            taskItem.Description = request.Description;
            taskItem.IsComplete = request.IsComplete;

            await _context.SaveChangesAsync(cancellationToken);

            return new TaskItemDto
            {
                Id = request.Id,
                Title = request.Title,
                Description = request.Description,
                IsComplete = request.IsComplete,
            };
        }
    }
}