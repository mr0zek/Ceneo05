using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocFlow.Domain.Documents.Numbers
{
  internal class NumberGeneratorProxy : INumberGenerator
  {
    private readonly INumberGenerator _generator;
    private readonly INumberGenerator _externalNumberGenerator;

    public NumberGeneratorProxy(INumberGenerator generator, INumberGenerator externalNumberGenerator)
    {
      _generator = generator;
      _externalNumberGenerator = externalNumberGenerator;
    }

    public DocumentNumber Generate()
    {
      DocumentNumber documentNumber = _externalNumberGenerator.Generate();
      if (documentNumber == null)
      {
        return _generator.Generate();
      }
      return documentNumber;
    }    
  }
}