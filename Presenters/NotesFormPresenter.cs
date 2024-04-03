using StickyNotesDemo.Models;

namespace StickyNotesDemo.Presenters
{
    public class NotesFormPresenter : INotesFormPresenter
    {
        private readonly INoteForm _view;
        private readonly INotesRepository _repository;

        public NotesFormPresenter(INoteForm view, INotesRepository repository)
        {
            _view = view;
            _repository = repository;
            _view.SetData(repository.GetAll());
        }

        public Note CreateNote()
        {
            NoteDetailsForm noteDetailsForm = new();
            var noteDetailsFormPresenter = new NoteDetailsFormPresenter(noteDetailsForm);
            noteDetailsForm.NoteDetailsFormPresenter = noteDetailsFormPresenter;
            var note = noteDetailsFormPresenter.CreateNote();
            _repository.Add(note);
            return note;
        }

        public Note UpdateNote(Guid id)
        {
            var note = _repository.GetNoteById(id);
            if (note != null)
            {
                NoteDetailsForm noteDetailsForm = new(note.Title, note.Content);
                var noteDetailsFormPresenter = new NoteDetailsFormPresenter(noteDetailsForm);
                noteDetailsForm.NoteDetailsFormPresenter = noteDetailsFormPresenter;
                noteDetailsFormPresenter.EditNote(ref note);
                _repository.Update(note);
                return note;
            }
            return null;
        }

        public void DeleteNote(Guid id)
        {
            var note = _repository.GetNoteById(id);
            if (note != null)
            {
                _repository.Remove(note);
            }
        }

        public void FindItems(string text)
        {
            var notes = _repository.GetNotesByTitleContent(text);
            foreach (var note in notes)
            {
                _view.InsertItem(note);
            }
        }
    }
}
