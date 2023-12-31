using CQRS.Practico.Application.DTOs;
using CQRS.Practico.Infrastructure.Data;
using CQRS.Practico.Infrastructure.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Practico.Application.Handlers
{
    public class GetAllTaskHandler : IRequestHandler<GetAllTaskQuery, IEnumerable<TaskItemDto>>
    {
        private readonly AppDbContext _appDbContext;

        public GetAllTaskHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<TaskItemDto>> Handle(GetAllTaskQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _appDbContext.TaskItems.ToListAsync(cancellationToken);

            return tasks.Select(x => new TaskItemDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                IsComplete = x.IsComplete,
            });
        }
    }
}
