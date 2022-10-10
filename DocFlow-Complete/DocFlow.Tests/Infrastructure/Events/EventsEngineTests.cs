using DocFlow.Domain.Documents;
using DocFlow.Domain.Documents.Events;
using DocFlow.Infrastructure.Events;
using Moq;
using NUnit.Framework;

namespace DocFlow.Tests.Infrastructure.Events
{
  [TestFixture]
  public class EventsEngineTests
  {
    private Mock<IEventListener<DocumentPublishedEvent>> _documentPublishedEventListenerMock;

    [SetUp]
    public void Setup()
    {
      _documentPublishedEventListenerMock = new Mock<IEventListener<DocumentPublishedEvent>>();  
    }

    [Test]
    public void StandardScenario()
    {
      // Arrange
      DocumentPublishedEvent @event = new DocumentPublishedEvent(new DocumentNumber("de/344"));
      EventsEngine.Instance.RegisterListener(_documentPublishedEventListenerMock.Object);

      // Act
      EventsEngine.Instance.Publish(@event);

      // Assert
      _documentPublishedEventListenerMock.Verify(f=>f.Handle(@event));
    }
  }
}
