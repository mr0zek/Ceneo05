namespace DocFlow.Domain.Documents.Events
{
  internal class DocumentVerifiedEvent : IEvent
  {
    public DocumentNumber Number { get; private set; }

    public DocumentVerifiedEvent(DocumentNumber number)
    {
      Number = number;      
    }
  }
}