using Essensys.Domain.Common;
using System.Threading.Tasks;

namespace Essensys.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
