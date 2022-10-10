using System;

namespace DocFlow.Domain.Documents.Events
{
  [Serializable]
  public class DocumentPublishedEvent : IEvent
  {
    public DocumentNumber Number { get; private set; }

    public DocumentPublishedEvent(DocumentNumber number)
    {
      Number = number;
    }    
  }
}