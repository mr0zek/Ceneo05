using DocFlow.Domain.Documents.Cost;
using DocFlow.Domain.Documents.Events;
using DocFlow.Domain.Documents.Export;
using DocFlow.Domain.Documents.Statemachine;
using DocFlow.Domain.Documents.Validation;
using DocFlow.Domain.Shared;
using DocFlow.Domain.Users;
using System;
using System.Collections.Generic;
using System.IO;
using DocFlow.Domain.Documents.Copier;

namespace DocFlow.Domain.Documents
{
  public class Document : IDocumentInternal
  {
    private readonly IDocumentValidator _validator;
    private readonly IEventsPublisher _publisher;

    public DocumentNumber Number { get; private set; }

    private IDictionary<DocumentStatus, IDocumentState> _documentStatuses = new Dictionary<DocumentStatus, IDocumentState>();
    private IDocumentState _currentState;

    public DocumentStatus Status
    {
      get
      {
        return _currentState.Status;
      }
    }

    public DocumentType Type { get; private set; }

    public User Author { get; private set; }

    public string Title { get; private set; }

    public DateTime CreateDate { get; private set; }

    public DateTime? ExpiryDate { get; internal set; }

    public Money PrintingCost { get; private set; }

    public int PageCount { get; internal set; }

    public string Body { get; set; }

    public Document(DocumentType type, User author, DocumentNumber number, DateTime created, IDocumentValidator validator, IEventsPublisher publisher)
    {
      _validator = validator;
      _publisher = publisher;
      Type = type;
      Author = author;
      Number = number;
      CreateDate = created;

      _documentStatuses.Add(DocumentStatus.DRAFT, new Draft(this, validator, publisher));
      _documentStatuses.Add(DocumentStatus.PUBLISHED, new Published(this, validator, publisher));
      _documentStatuses.Add(DocumentStatus.VERIFIED, new Verified(this, validator, publisher));
      _documentStatuses.Add(DocumentStatus.ARCHIVED, new Archived(this, validator, publisher));
      _currentState = _documentStatuses[DocumentStatus.DRAFT];            
    }

    void IDocumentInternal.SetTitle(string newTitle)
    {
      Title = newTitle;
    }

    void IDocumentInternal.SetStatus(DocumentStatus documentStatus)
    {
      _currentState = _documentStatuses[documentStatus];
    }

    void IDocumentInternal.SetPrintingCost(Money cost)
    {
      PrintingCost = cost;
    }

    public void ChangeTitle(string newTitle)
    {
      _currentState.ChangeTitle(newTitle);
    }

    public void Verify(User verifier)
    {
      _currentState.Verify(verifier);
    }

    public void Publish(ICostCalculator costCalculator)
    {
      _currentState.Publish(costCalculator);
    }

    public void Archive()
    {
      var result = _validator.Validate(this, DocumentStatus.ARCHIVED);
      if (result.Count > 0)
      {
        throw new DocumentOpeartionException(this.Number, string.Join(Environment.NewLine, result));
      }
      _currentState = _documentStatuses[DocumentStatus.ARCHIVED];
      _publisher.Publish(new DocumentArchivedEvent(Number));
    }

    public byte[] Export(IDocumentExporter documentExporter)
    {
      documentExporter.ExportNumber(Number);
      documentExporter.ExportTitle(Title);
      documentExporter.ExportExpiryDate(ExpiryDate);
      documentExporter.ExportStatus(Status);
      documentExporter.ExportType(Type);
      documentExporter.ExportAuthor(Author);
      return documentExporter.Build();
    }

    public void Created()
    {
      // Added for better test readability
    }
  }
}