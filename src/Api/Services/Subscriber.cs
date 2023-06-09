using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Andreani.ARQ.AMQStreams.Interface;
using Andreani.Scheme.Onboarding;
using onboardingworker.Application.UseCase.V1.PedidoOperation.Command.Update;

namespace Api.Services
{
    public class Subscriber : ISubscriber
    {
        private ILogger<ISubscriber> _logger;
        private ISender _mediator;
        private Andreani.ARQ.AMQStreams.Interface.IPublisher _publisher;

        public Subscriber(ILogger<Subscriber> logger,ISender mediator, Andreani.ARQ.AMQStreams.Interface.IPublisher publisher)
        {
            _logger = logger;
            _mediator = mediator;
            _publisher = publisher;


        }
        public async Task RecivePedidoCreado(Pedido response)
        {
            Pedido pedidoPublisher = await _mediator.Send(new UpdatePedidoCommand() { pedido = response });
            await _publisher.To<Pedido>(pedidoPublisher, pedidoPublisher.id.ToString());

        }
    }
}
