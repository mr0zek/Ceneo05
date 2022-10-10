using System;
using System.Collections.Generic;

namespace DocFlow.Domain.Documents
{
  public interface IDocumentRepository
  {
    void Save(Document documentInternal);

    Document Get(DocumentNumber number);

    Document Get(Guid id);

    IEnumerable<Document> GetAll();
  }
}