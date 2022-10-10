namespace DocFlow.Domain.Documents.Events
{
  public interface IEventsPublisher
  {
    void Publish<T>(T @event) where T : IEvent;
  }
}