using System;
using DocFlow.Domain.Documents;

namespace DocFlow.Application.Services
{
  public class DocumentSearchCriteria
  {
    public bool? Expired { get; set; }
    public bool? Published { get; set; }
    public bool? WillExpireInWeek { get; set; }
    public DocumentType? Type { get; set; }
    public Guid? AuthorId { get; set; }
  }
}