using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DocFlow.Domain.Documents.Statemachine;
using DocFlow.Domain.Users;

namespace DocFlow.Domain.Documents.Export
{
  public class CsvExporter : IDocumentExporter
  {
    private DocumentNumber _number;
    private string _title;
    private DocumentStatus _status;
    private DateTime? _expiryDate;
    private User _author;
    private DocumentType _documentType;

    public void ExportNumber(DocumentNumber number)
    {
      _number = number;
    }

    public void ExportTitle(string title)
    {
      _title = title;
    }

    public void ExportType(DocumentType type)
    {
      _documentType = type;
    }

    public void ExportStatus(DocumentStatus documentStatus)
    {
      _status = documentStatus;
    }

    public void ExportExpiryDate(DateTime? date)
    {
      _expiryDate = date;
    }

    public void ExportAuthor(User author)
    {
      _author = author;
    }

    public byte[] Build()
    {
      return Encoding.UTF8.GetBytes(string.Format("{0};{1};{2};{3};{4};{5}",
                                                  _number,
                                                  _title,
                                                  _status,
                                                  _documentType,
                                                  _expiryDate,
                                                  _author.Name));
    }
  }
}