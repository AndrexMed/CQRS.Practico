using CQRS.Practico.Application.DTOs;
using CQRS.Practico.Infrastructure.Data;
using CQRS.Practico.Infrastructure.Queries;
using MediatR;

namespace CQRS.Practico.Application.Handlers
{
    public class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, TaskItemDto>
    {
        private readonly AppDbContext _appDbContext;
        public GetTaskByIdHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<TaskItemDto> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var taskItem = await _appDbContext.TaskItems.FindAsync(
              new object[] { request.Id }, cancellationToken);

            if (taskItem == null)
            {
                return null!;
            }

            return new TaskItemDto
            {
                Id = taskItem.Id,
                Title = taskItem.Title,
                Description = taskItem.Description,
                IsComplete = taskItem.IsComplete,
            };
        }
    }
}