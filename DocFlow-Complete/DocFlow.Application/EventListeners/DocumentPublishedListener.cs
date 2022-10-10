using DocFlow.Application.Services;
using DocFlow.Domain.Documents.Events;
using DocFlow.Infrastructure.Events;

namespace DocFlow.Application.EventListeners
{
  public class DocumentPublishedListener : IEventListener<DocumentPublishedEvent>
  {
    private PrintingFacade printingFacade = new PrintingFacade();

    public void Handle(DocumentPublishedEvent @event)
    {
      int copies = 10; //TODO load from conf
      printingFacade.Print(@event.Number, copies);
    }
  }
}