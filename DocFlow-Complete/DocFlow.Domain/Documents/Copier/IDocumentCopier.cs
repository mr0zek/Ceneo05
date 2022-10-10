namespace DocFlow.Domain.Documents.Copier
{
  public interface IDocumentCopier
  {
    Document Copy(Document source);
  }
}