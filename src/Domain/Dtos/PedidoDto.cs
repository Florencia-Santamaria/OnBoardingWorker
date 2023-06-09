using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onboardingworker.Domain.Dtos
{
    public record struct PedidoDto(
            Guid id,
            int? numeroDePedido,
            int? estadoDelPedido
            ) { }
}
