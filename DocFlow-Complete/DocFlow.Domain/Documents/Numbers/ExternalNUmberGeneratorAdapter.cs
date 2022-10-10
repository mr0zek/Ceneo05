using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocFlow.Domain.Documents.Numbers
{
  internal class ExternalNumberGeneratorAdapter : INumberGenerator
  {
    private readonly ExternalNumberGenerator _numberGenerator;

    public ExternalNumberGeneratorAdapter(ExternalNumberGenerator numberGenerator)
    {
      _numberGenerator = numberGenerator;
    }

    public DocumentNumber Generate()
    {
      var number = _numberGenerator.Generate();

      return new DocumentNumber(number.PrimaryNumber + number.SecondaryNumber + number.VersionNumber);
    }
  }
}