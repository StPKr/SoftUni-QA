using GetGreeting;
using Moq;

namespace GetGreetinTest
{
    public class GreetingProviderTest
    {
        private GreetingProvider _greetingProvider;
        private Mock<TimeProvider> _mockedTimeProvider;

        [SetUp]
        public void Setup()
        {
            _mockedTimeProvider = new Mock<TimeProvider>();
            _greetingProvider = new GreetingProvider(_mockedTimeProvider.Object);
        }

        [Test]
        public void GetGreeting_ShouldReturnAMorningMessage_WhenItIsMorning()
        {
            _mockedTimeProvider.Setup(x => x.GetCurrentTime()).Returns(new DateTime(2000, 2, 2, 9, 9, 9));
            var result = _greetingProvider.GetGreeting();
            Assert.AreEqual("Good morning!", result);
        }

        [Test]
        public void GetGreeting_ShouldReturnAfternoonMessage_WhenIsAfternoon()
        {
            _mockedTimeProvider.Setup(x => x.GetCurrentTime()).Returns(new DateTime(2000, 2, 2, 13, 13, 13));
            var result = _greetingProvider.GetGreeting();
            Assert.That(result, Is.EqualTo("Good afternoon!"));
        }
        [Test]
        public void GetGreeting_ShouldReturnEveningMessage_WhenIsEvening()
        {
            _mockedTimeProvider.Setup(x => x.GetCurrentTime()).Returns(new DateTime(2000, 2, 2, 19, 19, 19));
            var result = _greetingProvider.GetGreeting();
            Assert.That(result, Is.EqualTo("Good evening!"));
        }
        [Test]
        public void GetGreeting_ShouldReturnNightMessage_WhenIsNight()
        {
            _mockedTimeProvider.Setup(x => x.GetCurrentTime()).Returns(new DateTime(2000, 2, 2, 4, 19, 19));
            var result = _greetingProvider.GetGreeting();
            Assert.That(result, Is.EqualTo("Good night!"));
        }
    }
}