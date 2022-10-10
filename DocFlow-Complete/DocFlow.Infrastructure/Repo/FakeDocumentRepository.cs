using DocFlow.Domain.Documents;
using System;
using System.Collections.Generic;

namespace DocFlow.Infrastructure.Repo
{
  public class FakeDocumentRepository : IDocumentRepository
  {
    private static IDictionary<DocumentNumber, Document> fakeDatatbase = new Dictionary<DocumentNumber, Document>();

    public void Save(Document documentInternal)
    {
      fakeDatatbase[documentInternal.Number] = documentInternal;
    }

    public Document Get(DocumentNumber number)
    {
      return fakeDatatbase[number];
    }

    public Document Get(Guid id)
    {
      // TODO Auto-generated method stub
      return null;
    }

    public IEnumerable<Document> GetAll()
    {
      return fakeDatatbase.Values;
    }
  }
}