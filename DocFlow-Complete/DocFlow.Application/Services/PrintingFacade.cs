using DocFlow.Domain.Documents;

namespace DocFlow.Application.Services
{
  public class PrintingFacade
  {
    public void Print(DocumentNumber document, int copies)
    {
      for (int i = 0; i < copies; i++)
        System.Console.WriteLine("Printing " + document);
    }
  }
}
