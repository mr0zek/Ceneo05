using DocFlow.Domain.Users;
using System;
using System.IO;

namespace DocFlow.Domain.Documents
{
  public class CSVExporter : IExporter
  {
    private DocumentNumber _number;
    private User _author;

    public Stream Build()
    {
      MemoryStream s = new MemoryStream();
      using (StreamWriter sw = new StreamWriter(s))
      {
        sw.Write(_number);
        sw.Write(";");        
      }

      return s;
    }

    public void ExportAuthor(User author)
    {
      _author = author;
    }

    public void ExportNumber(DocumentNumber number)
    {
      _number = number;
    }    
  }
}