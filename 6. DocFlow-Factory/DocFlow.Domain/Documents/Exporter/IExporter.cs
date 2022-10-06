using DocFlow.Domain.Users;
using System.IO;

namespace DocFlow.Domain.Documents
{
  public interface IExporter
  {    
    void ExportNumber(DocumentNumber number);
    void ExportAuthor(User author);
    Stream Build();
  }
}