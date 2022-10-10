using DocFlow.Domain.Users;
using System;

namespace DocFlow.Domain.Documents.Copier
{
  public abstract class TemplateDocumentCopier : IDocumentCopier
  {
    public Document Copy(Document source)
    {
      Document document = CreateDocument(source.Type, source.Author, source.Number, CalculateExpiryDate(source));
      document.ChangeTitle(source.Title);
      document.PageCount = source.PageCount;
      
      return document;
    }

    protected abstract DateTime CalculateExpiryDate(Document document);

    protected abstract Document CreateDocument(DocumentType type, User author, DocumentNumber number, DateTime expiryDate);
  }
}