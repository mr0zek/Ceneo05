namespace DocFlow.Domain.Documents.Numbers
{
  internal class SufixNumberGeneratorDekorator : NumberGeneratorBase
  {
    private readonly string _sufix;

    public SufixNumberGeneratorDekorator(INumberGenerator numberGenerator, string sufix)
      : base(numberGenerator)
    {
      _sufix = sufix;
    }

    public override DocumentNumber Generate()
    {
      return new DocumentNumber(_numberGenerator.Generate().Number + _sufix);
    }
  }
}