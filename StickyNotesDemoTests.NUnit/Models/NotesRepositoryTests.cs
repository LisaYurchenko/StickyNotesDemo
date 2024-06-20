using Microsoft.EntityFrameworkCore;
using Moq;
using StickyNotesDemo.Models;

namespace StickyNotesDemoTests.NUnit.Models
{
    [TestFixture]
    public class NotesRepositoryTests
    {
        private Mock<NotesContext> _mockNotesContext;
        private NotesRepository _notesRepository;
        private Note _note;

        [SetUp]
        public void SetUp()
        {
            _mockNotesContext = new Mock<NotesContext>();
            var notesList = new List<Note>();
            var lstDataQueryable = notesList.AsQueryable();
            var dbSetMock = new Mock<DbSet<Note>>();

            dbSetMock.As<IQueryable<Note>>().Setup(s => s.Provider).Returns(lstDataQueryable.Provider);
            dbSetMock.As<IQueryable<Note>>().Setup(s => s.Expression).Returns(lstDataQueryable.Expression);
            dbSetMock.As<IQueryable<Note>>().Setup(s => s.ElementType).Returns(lstDataQueryable.ElementType);
            dbSetMock.As<IQueryable<Note>>().Setup(s => s.GetEnumerator()).Returns(() => lstDataQueryable.GetEnumerator());
            dbSetMock.Setup(x => x.Add(It.IsAny<Note>())).Callback<Note>(notesList.Add);
            dbSetMock.Setup(x => x.Remove(It.IsAny<Note>())).Callback<Note>(t => notesList.Remove(t));

            _mockNotesContext.Setup(nc => nc.Notes).Returns(dbSetMock.Object);
            _notesRepository = new NotesRepository(_mockNotesContext.Object);
            _note = new Note();
        }

        [Test]
        public void AddNoteAddsNoteToTheRepository()
        {
            // Arrange
            // Act
            _notesRepository.Add(_note);

            var all = _notesRepository.GetAll().ToList();

            // Assert
            Assert.That(all, Has.Member(_note));
        }

        [Test]
        public void DeleteNote_RemovesNoteFromTheRepository()
        {
            // Arrange
            _notesRepository.Add(_note);

            // Act
            _notesRepository.Remove(_note);
            var all = _notesRepository.GetAll().ToList();
            // Assert
            Assert.That(all, Has.No.Member(_note));
        }

        [Test]
        public void UpdateNote_ReturnsCorrectTitleAndContent()
        {
            // Arrange
            _notesRepository.Add(_note);
            _note.Title = "title";
            _note.Content = "content";
            // Act
            _notesRepository.Update(_note);
            var newNote = _notesRepository.GetNoteById(_note.Id);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(newNote.Title, Is.EqualTo(_note.Title));
                Assert.That(newNote.Content, Is.EqualTo(_note.Content));
            });
        }

        [Test]
        public void GetNoteByTitle_ReturnsCorrectNote()
        {
            // Arrange
            _note.Title = "title";
            _notesRepository.Add(_note);

            // Act
            var foundItem = _notesRepository.GetNoteByTitle(_note.Title);

            // Assert
            Assert.That(foundItem.Title, Is.EqualTo(_note.Title));
        }
    }
}
