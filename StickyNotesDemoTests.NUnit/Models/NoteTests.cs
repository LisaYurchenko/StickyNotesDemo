using NUnit.Framework;
using StickyNotesDemo.Models;

namespace StickyNotesDemoTests.NUnit.Models
{
    [TestFixture]
    public class NoteTests
    {
        private Note _note;
        [SetUp]
        public void SetUp()
        {
            _note = new Note();
        }

        [Test]
        public void PropertiesAreNotNullByDefault()
        {
            // Arrange
            // Act
            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(_note.Content, Is.Not.Null);
                Assert.That(_note.Title, Is.Not.Null);
                Assert.That(_note.Id, Is.Not.Empty);
                Assert.That(_note.CreationDate, Is.Not.EqualTo(new DateTime()));
            });
        }

        [TestCase("title", "content")]
        [TestCase("23423423", "conte88888nt")]
        [TestCase("fghhdfhdfh", "contejgjjhgghjgnt")]
        [TestCase("", "")]
        public void TitleAndContentAreSetByConstructor(string expectedTitle, string expectedContent)
        {
            // Arrange
            //Act
            var note = new Note(expectedTitle, expectedContent);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(expectedTitle, Is.EqualTo(note.Title));
                Assert.That(expectedContent, Is.EqualTo(note.Content));
            });
        }

        [Test]
        public void IdIsNotDefault()
        {
            //Arrange
            //Act
            //Assert
            Assert.That(Guid.Empty, Is.Not.EqualTo(_note.Id));
        }

        [Test]
        public void DateTimeIsNotDefault()
        {
            //arrange
            //act
            _note.CreationDate = new DateTime();
            //asserts
            Assert.That(new DateTime(), Is.Not.EqualTo(_note.CreationDate));
        }

        [Test]
        public void DateTimeIsApplied()
        {
            //arrange
            var expectedValue = DateTime.Now;
            //act
            _note.CreationDate = expectedValue;
            //assert
            Assert.That(expectedValue, Is.EqualTo(_note.CreationDate));
        }
    }
}