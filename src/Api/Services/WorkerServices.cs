using onboardingworker.Application.UseCase.V1.PersonOperation.Queries.GetList;
using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Services
{
    public class WorkerServices : BackgroundService
    {
        private readonly ILogger<WorkerServices> _logger;
        private readonly ISender _mediator;

        public WorkerServices(ILogger<WorkerServices> logger, ISender mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Ejemplo de BackgroundServices");

            await _mediator.Send(new ListPerson());
        }
    }
}
