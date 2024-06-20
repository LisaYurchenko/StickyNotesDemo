using Moq;
using StickyNotesDemo;
using StickyNotesDemo.Models;
using StickyNotesDemo.Presenters;

namespace StickyNotesDemoTests.NUnit.Presenters
{
    [TestFixture]
    public class NoteDetailsFormPresenterTests
    {
        private Mock<INoteDetailsForm> _view;
        private NoteDetailsFormPresenter _presenter;

        [SetUp]
        public void SetUp()
        {
            _view = new Mock<INoteDetailsForm>();
            _presenter = new NoteDetailsFormPresenter(_view.Object);
        }

        [Test]
        public void CreateNoteTest()
        {
            // Arrange
            // Act
            var note = _presenter.CreateNote();

            // Assert
            Assert.That(note, Is.Not.Null);
        }

        [Test]
        public void EditNoteTest()
        {
            //Arrange
            _view.Setup(x => x.Title).Returns("NewTitle");
            _view.Setup(x => x.Content).Returns("NewContent");

            var note = new Note();

            // Act
            _presenter.EditNote(ref note);

            // Assert
            Assert.Multiple(() =>
            {
                _view.Verify(x => x.ShowDialog(), Times.Once);
                Assert.That(note.Title, Is.EqualTo("NewTitle"));
                Assert.That(note.Content, Is.EqualTo("NewContent"));
            });
        }
    }

}
