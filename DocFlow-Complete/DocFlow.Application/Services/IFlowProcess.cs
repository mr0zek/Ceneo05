using System;
using DocFlow.Domain.Documents;

namespace DocFlow.Application.Services
{
  public interface IFlowProcess
  {
    DocumentNumber CreateDocument(Guid creatorId, DocumentType type, string title);
    void VerifyDocument(Guid verifierId, DocumentNumber documentNumber);
    void PublishDocument(DocumentNumber documentNumber);
    DocumentNumber CreateNewVersion(DocumentNumber documentNumber);
    void Correct(Guid correctorId, DocumentNumber documentNumber);
  }
}