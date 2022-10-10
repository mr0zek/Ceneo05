using System.Collections.Generic;

namespace DocFlow.Infrastructure
{
  public class ErrorLog : IErrorLog
  {
    IList<string> _errors = new List<string>();

    private ErrorLog()
    {      
    }

    private static ErrorLog _instance;
    public static IErrorLog Instance
    {
      get
      {
        if(_instance == null)
        {
          _instance = new ErrorLog();
        }
        return _instance;
      }
    }

    public void RegisterError(string message)
    {
      _errors.Add(message);
    }
  }
}