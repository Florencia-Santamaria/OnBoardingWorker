using Andreani.ARQ.AMQStreams.Interface;
using Andreani.ARQ.AMQStreams.Services;
using Andreani.ARQ.Core.Interface;
using Andreani.ARQ.Pipeline.Clases;
using Andreani.Scheme.Onboarding;
using MediatR;
using Microsoft.Extensions.Logging;
using onboardingworker.Application.UseCase.V1.PersonOperation.Commands.Update;
using onboardingworker.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace onboardingworker.Application.UseCase.V1.PedidoOperation.Command.Update
{
    public class UpdatePedidoCommand : IRequest<Pedido>
    {
        public Pedido pedido { get; set; }
    }
    public class UpdatePedidoHandler : IRequestHandler<UpdatePedidoCommand, Pedido>
    {
        

        //public UpdatePedidoHandler()
        //{
            
        //}

            public async Task<Pedido> Handle(UpdatePedidoCommand request, CancellationToken cancellationToken)
        {
         Pedido pedidoActualizado= request.pedido;
            pedidoActualizado.numeroDePedido=new Random().Next();
            pedidoActualizado.estadoDelPedido = 2.ToString();

          
          return pedidoActualizado;
        }
    }
}
