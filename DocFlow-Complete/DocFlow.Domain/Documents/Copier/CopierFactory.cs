namespace DocFlow.Domain.Documents.Copier
{
  public class CopierFactory
  {
    private readonly IDocumentFactory _documentFactory;

    public CopierFactory(IDocumentFactory documentFactory)
    {
      _documentFactory = documentFactory;
    }

    public IDocumentCopier Create()
    {
      return new StandardDocumentCopier(_documentFactory);
    }
  }
}