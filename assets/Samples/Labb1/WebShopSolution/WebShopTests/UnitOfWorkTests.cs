using Moq;
using WebShop.Notifications;

namespace WebShop.Tests
{
    public class UnitOfWorkTests
    {
        [Fact]
        public void NotifyProductAdded_CallsObserverUpdate()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Test" };

            // Skapar en mock av INotificationObserver
            var mockObserver = new Mock<INotificationObserver>();

            // Skapar en instans av ProductSubject och lägger till mock-observatören
            var productSubject = new ProductSubject();
            productSubject.Attach(mockObserver.Object);

            // Injicerar vårt eget ProductSubject i UnitOfWork
            var unitOfWork = new UnitOfWork.UnitOfWork(productSubject);

            // Act
            unitOfWork.NotifyProductAdded(product);

            // Assert
            // Verifierar att Update-metoden kallades på vår mock-observatör
            mockObserver.Verify(o => o.Update(product), Times.Once);
        }
    }
}
