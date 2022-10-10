using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocFlow.Domain.Documents.Numbers
{
  public class ExternalNumberGenerator
  {
    public ExternalNumber Generate()
    {
      return new ExternalNumber("123","21413","23");      
    }
  }

  public class ExternalNumber
  {
    public string PrimaryNumber { get; private set; }
    public string SecondaryNumber { get; private set; }
    public string VersionNumber { get; private set; }

    public ExternalNumber(string primaryNumber, string secondaryNumber, string versionNumber)
    {
      PrimaryNumber = primaryNumber;
      SecondaryNumber = secondaryNumber;
      VersionNumber = versionNumber;
    }
  }
}
