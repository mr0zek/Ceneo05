using DocFlow.Domain.Documents;
using DocFlow.Domain.Documents.Configuration;
using DocFlow.Domain.Documents.Cost;
using DocFlow.Domain.Documents.Events;
using DocFlow.Domain.Documents.Numbers;
using DocFlow.Domain.Documents.Statemachine;
using DocFlow.Domain.Documents.Validation;
using DocFlow.Domain.Users;
using Moq;
using System;
using DocFlow.Domain.Shared;

namespace DocFlow.Tests.Domain.Documents
{
  public class DocumentAssembler
  {
    private DocumentType _type = DocumentType.PROCEDURE;
    private DocumentStatus _status = DocumentStatus.DRAFT;
    private User _author = new User(Guid.NewGuid());
    private User _verifier = new User(Guid.NewGuid());
    private DateTime _createDate;
    private DocumentNumber _number;
    private Mock<IEventsPublisher> _eventsPublisher = new Mock<IEventsPublisher>();

    private FakeConfigurationData _configurationData = new FakeConfigurationData()
      {
        ColorPrintingEnabled = false,
        EnvName = "Demo",
        QualitySystem = QualitySystemType.ISO
      };

    public Document Build()
    {
      //Q: Czy wstrzykiwa validator czy mo¿e testowac cz³y dokument jako jednostke.

      var documentFactory = new DocumentFactory(
        NumberGeneratorFactory.Create(
          _author, 
          _configurationData), 
        _eventsPublisher.Object, 
        DocumentValidatorFactory.Create(_configurationData));

      Document doc = documentFactory.Create(_type, _author);

      if (_status > DocumentStatus.DRAFT)
      {
        doc.ChangeTitle("some title");
        doc.ExpiryDate = doc.CreateDate.AddYears(2);
        doc.Verify(_verifier);
      }
      if (_status > DocumentStatus.VERIFIED)
      {
        Mock<ICostCalculator> _costCalculatorMock = new Mock<ICostCalculator>();
        _costCalculatorMock.Setup(f => f.Calculate(doc)).Returns(new Money(10d));
        doc.Publish(_costCalculatorMock.Object);
      }
      return doc;
    }

    public DocumentAssembler Published()
    {
      _status = DocumentStatus.PUBLISHED;
      return this;
    }

    public DocumentAssembler CreatedBy(User author)
    {
      _author = author;
      return this;
    }

    public DocumentAssembler Verified()
    {
      _status = DocumentStatus.VERIFIED;
      return this;
    }
  }
}