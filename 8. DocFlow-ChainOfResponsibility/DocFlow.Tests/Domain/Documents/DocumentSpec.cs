using DocFlow.Domain.Documents;
using DocFlow.Domain.Documents.Validation;
using DocFlow.Domain.Users;
using Moq;
using System;
using Xunit;

namespace DocFlow.Infrastructure.Repo
{
  public class DocumentSpec
  {
    private static DocumentType TYPE = DocumentType.PROCEDURE;
    private static User CREATOR = new User(Guid.NewGuid());
    private static User VERIFIER = new User(Guid.NewGuid());
    private Mock<IDocumentValidator> _documentValidatorMock = new Mock<IDocumentValidator>();
    private DocumentAssembler _documentAssembler = new DocumentAssembler();
    private Document _doc;
    
    [Fact]
    public void Can_Not_Verify_By_Author()
    {
      // Arrange
      Document document = new Document(TYPE, CREATOR, new DocumentNumber("1"), _documentValidatorMock.Object);

      // Act, Assert
      Assert.Throws<DocumentOpeartionException>(() => document.Verify(CREATOR));
    }

    [Fact]
    public void Should_Back_To_Draft_When_Changing_Title()
    {
      // Arrange
      //TODO zamienic na Assembler


      ArrangeDocument().Verified();
      // Act
      ActOnDocument().ChangeTitle("title 2");

      // Assert

      AssertDocument().IsDraft();
      //TODO zamienic na AssertObject
      Assert.Equal(DocumentStatus.DRAFT, _doc.Status);
    }
  
    private DocumentAssert AssertDocument()
    {
      return new DocumentAssert(_doc);
    }

    private Document ActOnDocument()
    {
      return _doc = _documentAssembler.Build();
    }

    private DocumentAssembler ArrangeDocument()
    {
      return _documentAssembler;
    }

    [Fact]
    public void Should_Publish_Verified()
    {
      // Arrange
      //TODO zamienic na Assembler
      Document document = new Document(TYPE, CREATOR, new DocumentNumber("1"), _documentValidatorMock.Object);
      document.Verify(VERIFIER);
      //when
      document.Publish(null);
      // Act
      //TODO zamienic na AssertObject
      Assert.Equal(DocumentStatus.PUBLISHED, document.Status);
    }
  }
}