﻿namespace DocFlow.Domain.Documents.Numbers
{
  internal class PrefixNumberDecorator : NumberGeneratorBase
  {
    private readonly string _prefix;

    public PrefixNumberDecorator(INumberGenerator numberGenerator, string prefix)
      : base(numberGenerator)
    {
      _prefix = prefix;
    }

    public override DocumentNumber Generate()
    {
      return new DocumentNumber(_prefix + _numberGenerator.Generate().Number);
    }
  }
}