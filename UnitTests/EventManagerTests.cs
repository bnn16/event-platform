using event_platform_classLibrary;
using event_platform_classLibrary.EventHandlers.Classes;
using Moq;
using NUnit.Framework;
using System.Data;


namespace UnitTests
{
    [TestFixture]
    public class EventManagerTests
    {
        private EventManager _eventManager;
        private Mock<IDBController> _dbControllerMock;

        [SetUp]
        public void Setup()
        {
            _dbControllerMock = new Mock<IDBController>();
            _eventManager = new EventManager(_dbControllerMock.Object);
        }

        [Test]
        public void CreateEvent_ReturnsNewEventInstance()
        {
            // Arrange
            int id = 1;
            string name = "Event Name";
            string description = "Event Description";
            DateTime date = DateTime.Now;
            int price = 100;
            string eventType = "Event Type";
            int capacity = 100;

            // Act
            Event result = _eventManager.CreateEvent(id, name, description, date, price, eventType, capacity);

            // Assert
            NUnit.Framework.Assert.IsNotNull(result);
            NUnit.Framework.Assert.AreEqual(id, result.Id);
            NUnit.Framework.Assert.AreEqual(name, result.Name);
            NUnit.Framework.Assert.AreEqual(description, result.Description);
            NUnit.Framework.Assert.AreEqual(date, result.Date);
            NUnit.Framework.Assert.AreEqual(price, result.Price);
            NUnit.Framework.Assert.AreEqual(eventType, result.EventType);
            NUnit.Framework.Assert.AreEqual(capacity, result.Capacity);
        }


        [Test]
        public void CreateConcertEvent_ReturnsNewConcertEventInstance()
        {
            // Arrange
            int id = 1;
            string name = "Concert Event Name";
            string description = "Concert Event Description";
            DateTime date = DateTime.Now;
            int price = 200;
            string eventType = "Concert Event Type";
            int capacity = 200;
            string artist = "Concert Artist";
            string venue = "Concert Venue";

            // Act
            ConcertEvent result = _eventManager.CreateConcertEvent(id, name, description, date, price, eventType, capacity, artist, venue);

            // Assert
            NUnit.Framework.Assert.IsNotNull(result);
            NUnit.Framework.Assert.AreEqual(id, result.Id);
            NUnit.Framework.Assert.AreEqual(name, result.Name);
            NUnit.Framework.Assert.AreEqual(description, result.Description);
            NUnit.Framework.Assert.AreEqual(date, result.Date);
            NUnit.Framework.Assert.AreEqual(price, result.Price);
            NUnit.Framework.Assert.AreEqual(eventType, result.EventType);
            NUnit.Framework.Assert.AreEqual(capacity, result.Capacity);
            NUnit.Framework.Assert.AreEqual(artist, result.Artist);
            NUnit.Framework.Assert.AreEqual(venue, result.Venue);
        }

        [Test]
        public async Task UpdateEventAsync_ValidEventAndId_ReturnsTrue()
        {
            // Arrange
            var eventToUpdate = new Event();
            int updateId = 1;
            _dbControllerMock.Setup(d => d.UpdateEventAsync(eventToUpdate, updateId, It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(true);

            // Act
            bool result = await _eventManager.UpdateEventAsync(eventToUpdate, updateId);

            // Assert
            NUnit.Framework.Assert.IsTrue(result);
            _dbControllerMock.Verify(d => d.UpdateEventAsync(eventToUpdate, updateId, It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public async Task DeleteEvent_ValidId_ReturnsTrue()
        {
            // Arrange
            int id = 1;
            _dbControllerMock.Setup(d => d.DeleteEvent(id)).ReturnsAsync(true);

            // Act
            bool result = await _eventManager.DeleteEvent(id);

            // Assert
            NUnit.Framework.Assert.IsTrue(result);
            _dbControllerMock.Verify(d => d.DeleteEvent(id), Times.Once);
        }

        // Add more unit tests for the other methods in EventManager
        // ...

        [Test]
        public async Task GetAllEvents_ReturnsDataTable()
        {
            // Arrange
            var expectedDataTable = new DataTable();
            _dbControllerMock.Setup(d => d.GetAllEvents()).Returns(expectedDataTable);

            // Act
            DataTable actualDataTable = _eventManager.GetAllEvents();

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedDataTable, actualDataTable);
            _dbControllerMock.Verify(d => d.GetAllEvents(), Times.Once);
        }
    }
}
