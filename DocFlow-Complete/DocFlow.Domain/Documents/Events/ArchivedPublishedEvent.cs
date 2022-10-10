using System;

namespace DocFlow.Domain.Documents.Events
{
  [Serializable]
  public class DocumentArchivedEvent : IEvent
  {
    public DocumentNumber Number { get; private set; }

    public DocumentArchivedEvent(DocumentNumber number)
    {
      Number = number;
    }
  }
}