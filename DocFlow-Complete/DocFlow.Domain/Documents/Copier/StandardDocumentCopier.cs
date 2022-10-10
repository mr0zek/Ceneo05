using System;
using DocFlow.Domain.Users;

namespace DocFlow.Domain.Documents.Copier
{
  class StandardDocumentCopier : TemplateDocumentCopier
  {
    private readonly IDocumentFactory _documentFactory;

    public StandardDocumentCopier(IDocumentFactory documentFactory)
    {
      _documentFactory = documentFactory;
    }

    protected override DateTime CalculateExpiryDate(Document document)
    {
      return document.CreateDate.AddYears(2);
    }

    protected override Document CreateDocument(DocumentType type, User author, DocumentNumber number, DateTime expiryDate)
    {
      return _documentFactory.Create(type, author, new DocumentNumber(number+"1"), expiryDate);
    }
  }
}