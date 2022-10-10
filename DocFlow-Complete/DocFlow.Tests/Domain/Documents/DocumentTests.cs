using DocFlow.Domain.Documents;
using DocFlow.Domain.Documents.Cost;
using DocFlow.Domain.Documents.Validation;
using DocFlow.Domain.Users;
using Moq;
using NUnit.Framework;
using System;

namespace DocFlow.Tests.Domain.Documents
{
  public class DocumentTests
  {
    private static User CREATOR = new User(Guid.NewGuid());
    private DocumentAssembler _documentAssembler = new DocumentAssembler();
    private Document _document;
    private Mock<ICostCalculator> _costCalculator;
    private Mock<IDocumentValidator> _documentValidator;

    [SetUp]
    public void Setup()
    {
      _costCalculator = new Mock<ICostCalculator>();
      _documentValidator = new Mock<IDocumentValidator>();
    }

    private DocumentAssert ThenDocument()
    {
      return new DocumentAssert(_document);
    }

    private Document ActOnDocument()
    {
      return _document = _documentAssembler.Build();
    }

    private DocumentAssembler ArrangeDocument()
    {
      return _documentAssembler;
    }

    [Test]
    public void New_Document_Should_Have_Number()
    {
      ActOnDocument().Created();

      ThenDocument().IsDraft();
    }

    [Test]
    public void Should_Throw_DocumentOpeartionException_When_Verified_By_Author()
    {
      // Arrange
      ArrangeDocument().CreatedBy(CREATOR);

      // Act, Assert
      Assert.Throws<DocumentOpeartionException>(() => ActOnDocument().Verify(CREATOR));
    }

    [Test]
    public void Should_Publish_Verified()
    {
      // Arrange
      ArrangeDocument().Verified();

      // Act
      ActOnDocument().Publish(_costCalculator.Object);

      // Assert
      ThenDocument().IsPublished();
    }

    [Test]
    public void Should_Throw_Exception_When_Publish_Second_Time()
    {
      //TODO: Wywalic komentarze; Adnotowac klasy
      // Arrange
      ArrangeDocument().Published();

      // Act
      Assert.Throws<DocumentOpeartionException>(() => ActOnDocument().Publish(_costCalculator.Object));
    }

    [Test]
    public void Should_Throw_Exception_When_Changing_Title_In_Publish_State()
    {
      // Arrange
      ArrangeDocument().Published();

      
      // Act
      Assert.Throws<DocumentOpeartionException>(() => ActOnDocument().ChangeTitle("fsds"));
    }
  }
}