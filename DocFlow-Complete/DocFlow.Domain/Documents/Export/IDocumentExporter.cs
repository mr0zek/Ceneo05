using System;
using System.IO;
using DocFlow.Domain.Documents.Statemachine;
using DocFlow.Domain.Users;

namespace DocFlow.Domain.Documents.Export
{
  public interface IDocumentExporter
  {
    void ExportNumber(DocumentNumber number);
    
    void ExportTitle(string title);

    void ExportType(DocumentType type);

    void ExportStatus(DocumentStatus documentStatus);

    void ExportExpiryDate(DateTime? date);

    void ExportAuthor(User author);

    byte[] Build();
    
  }
}