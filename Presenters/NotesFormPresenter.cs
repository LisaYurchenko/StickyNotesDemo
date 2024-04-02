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
        }

        public string[] CreateNote()
        {
            NoteDetailsForm noteDetailsForm = new();
            var noteDetailsFormPresenter = new NoteDetailsFormPresenter(noteDetailsForm);
            noteDetailsForm.NoteDetailsFormPresenter = noteDetailsFormPresenter;
            var note = noteDetailsFormPresenter.CreateNote();
            _repository.Add(note);
            return new string[] { note.Title, note.CreationDate.ToString() };
        }

        public string[]? UpdateNote(string title)
        {
            var note = _repository.GetNoteByTitle(title);
            if (note != null)
            {
                NoteDetailsForm noteDetailsForm = new(note.Title, note.Content);
                var noteDetailsFormPresenter = new NoteDetailsFormPresenter(noteDetailsForm);
                noteDetailsForm.NoteDetailsFormPresenter = noteDetailsFormPresenter;
                noteDetailsFormPresenter.EditNote(ref note);
                _repository.Update(note);
                return new string[] { note.Title, note.CreationDate.ToString() };
            }
            return null;
        }

        public void FindItems(string text)
        {
            var notes = _repository.GetNotesByTitleContent(text);
            foreach (var note in notes)
            {
                _view.InsertItem(new string[] { note.Title, note.CreationDate.ToString() });
            }
        }
    }
}
