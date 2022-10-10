using DocFlow.Domain.Documents.Numbers;
using NUnit.Framework;

namespace DocFlow.Tests.Domain.Number
{
  [TestFixture]
  public class IsoNumberGeneratorTests
  {
    [Test]
    public void Should_Generate_Next_Number()
    {
      // Arrange
      INumberGenerator sut = new IsoNumberGenerator();

      // Act
      var result = sut.Generate();

      // Assert
      Assert.AreEqual("1", result.Number);
    }
  }
}