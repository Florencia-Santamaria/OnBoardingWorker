using onboardingworker.Domain.Common;
using System.Threading.Tasks;

namespace onboardingworker.Application.Common.Interfaces;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}
