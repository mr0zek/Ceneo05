using DocFlow.Domain.Documents;
using DocFlow.Domain.Documents.Statemachine;
using NUnit.Framework;

namespace DocFlow.Tests.Domain.Documents
{
  public class DocumentAssert
  {
    private Document _document;

    public DocumentAssert(Document document)
    {
      _document = document;
    }

    public DocumentAssert IsPublished()
    {
      Assert.AreEqual(DocumentStatus.PUBLISHED, _document.Status);
      Assert.IsNotNull(_document.Title);
      Assert.IsNotNull(_document.Author);
      //...

      return this;
    }

    public void IsVerified()
    {
      Assert.AreEqual(DocumentStatus.VERIFIED, _document.Status);
    }

    public DocumentAssert IsDraft()
    {
      Assert.NotNull(_document.Number);
      Assert.IsFalse(_document.Number.Empty());
      return this;
    }
  }
}