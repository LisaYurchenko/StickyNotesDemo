using Moq;
using StickyNotesDemo;
using StickyNotesDemo.Models;
using StickyNotesDemo.Presenters;

namespace StickyNotesDemoTests.NUnit.Presenters
{
    [TestFixture]
    public class NotesFormPresenterTests
    {
        private Mock<INoteForm> _view;
        private Mock<INoteDetailsFormPresenter> _noteDetailsFormPresenter;
        private Mock<INotesRepository> _repository;
        private NotesFormPresenter _presenter;

        [SetUp]
        public void SetUp()
        {
            _view = new Mock<INoteForm>();
            _noteDetailsFormPresenter = new Mock<INoteDetailsFormPresenter>();
            _repository = new Mock<INotesRepository>();
            _presenter = new NotesFormPresenter(_view.Object, _noteDetailsFormPresenter.Object, _repository.Object);
        }

        [Test]
        public void CreateNoteTest()
        {
            // Arrange
            // Act
            var note = _presenter.CreateNote();

            // Assert
            _noteDetailsFormPresenter.Verify(p => p.CreateNote(), Times.Once);
            _repository.Verify(r => r.Add(It.IsAny<Note>()), Times.Once);
        }

        [Test]
        public void UpdateNoteTest()
        {

            // Arrange
            var note = new Note();
            _repository.Setup(r => r.GetNoteById(It.IsAny<Guid>())).Returns(note);

            // Act
            var updatedNote = _presenter.UpdateNote(note.Id);

            // Assert
            _noteDetailsFormPresenter.Verify(p => p.SetData(note), Times.Once);
            _noteDetailsFormPresenter.Verify(p => p.EditNote(ref note), Times.Once);
            _repository.Verify(r => r.Update(note), Times.Once);
            Assert.That(updatedNote, Is.EqualTo(note));
        }

        [Test]
        public void UpdateNote_ReturnsNull()
        {
            // Arrange
            _repository.Setup(r => r.GetNoteById(It.IsAny<Guid>())).Returns((Note)null);

            // Act
            var updatedNote = _presenter.UpdateNote(Guid.NewGuid());

            // Assert
            _noteDetailsFormPresenter.Verify(p => p.SetData(It.IsAny<Note>()), Times.Never);
            _noteDetailsFormPresenter.Verify(p => p.EditNote(ref It.Ref<Note>.IsAny), Times.Never);
            _repository.Verify(r => r.Update(It.IsAny<Note>()), Times.Never);
            Assert.That(updatedNote, Is.Null);
        }

        [Test]
        public void DeleteNoteTest()
        {

            // Arrange
            var note = new Note();
            _repository.Setup(r => r.GetNoteById(It.IsAny<Guid>())).Returns(note);

            // Act
            _presenter.DeleteNote(note.Id);

            // Assert
            _repository.Verify(r => r.Remove(note), Times.Once);
        }


        [Test]
        public void FindItemsTests()
        {
            // Arrange
            var notes = new List<Note> { new Note(), new Note() };
            _repository.Setup(r => r.GetNotesByTitleContent(It.IsAny<string>())).Returns(notes);

            // Act
            _presenter.FindItems("text");

            // Assert
            _repository.Verify(r => r.GetNotesByTitleContent("text"), Times.Once);
            _view.Verify(v => v.InsertItem(It.IsAny<Note>(), -1), Times.Exactly(notes.Count));
        }
    }
}

