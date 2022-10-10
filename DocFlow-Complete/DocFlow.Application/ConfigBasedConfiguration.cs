using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocFlow.Domain.Documents.Configuration;
using DocFlow.Domain.Documents.Numbers;

namespace DocFlow.Application
{
  class ConfigBasedConfiguration : IConfigurationData
  {
    public QualitySystemType QualitySystem
    {
      get
      {
        string val = System.Configuration.ConfigurationManager.AppSettings["QualitySystem"];
        if (val == null)
        {
          return QualitySystemType.ISO;
        }
        return (QualitySystemType)Enum.Parse(typeof(QualitySystemType), val);
      }
    }
    public string EnvName
    {
      get
      {
        return System.Configuration.ConfigurationManager.AppSettings["EnvName"];        
      }
    }

    public bool ColorPrintingEnabled
    {
      get
      {
        string val = System.Configuration.ConfigurationManager.AppSettings["ColorPrintingEnabled"];
        if (val == null || val.ToUpper() == "FALSE")
        {
          return false;
        }
        return true;
      }
    }
  }
}
