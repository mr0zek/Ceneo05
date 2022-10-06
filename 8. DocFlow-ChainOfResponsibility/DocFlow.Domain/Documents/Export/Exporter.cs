using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocFlow.Domain.Documents.Export
{
  public interface IExporter
  {
    void BuildTitle(string title);
    void BuildStatus(DocumentStatus status);
    void BuildExpirationDate(DateTime expirationDate);
    Stream Build();
  }

  public class CSVExporter: IExporter
  {
    private DocumentStatus _status;
    private string _title;
    private DateTime _expirationDate;

    public void BuildTitle(string title)
    {
      _title = title;
    }

    public void BuildStatus(DocumentStatus status)
    {
      _status = status;
    }

    public void BuildExpirationDate(DateTime expirationDate)
    {
      _expirationDate = expirationDate;
    }

    public Stream Build()
    {
      MemoryStream s = new MemoryStream();
      using (StreamWriter sw = new StreamWriter(s))
      {
        sw.Write(_title);
        sw.Write("|");
        sw.Write(_status);
        sw.Write("|");
        sw.Write(_expirationDate);
      }
      return s;
    }
  }
}
