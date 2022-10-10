using DocFlow.Domain.Documents.Events;

namespace DocFlow.Infrastructure.Events
{
  public interface IEventListener<E> where E : IEvent
  {
    void Handle(E @event);
  }
}
