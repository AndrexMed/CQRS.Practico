using CQRS.Practico.Infrastructure.Commands;
using CQRS.Practico.Infrastructure.Data;
using MediatR;

namespace CQRS.Practico.Application.Handlers
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, bool>
    {
        private readonly AppDbContext _appDbContext;

        public DeleteTaskHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var taskItem = await _appDbContext.TaskItems.FindAsync(
               new object[] { request.Id }, cancellationToken);

            if (taskItem == null)
            {
                return false;
            }

            _appDbContext.TaskItems.Remove(taskItem);
            await _appDbContext.SaveChangesAsync();

            return true;
        }
    }
}