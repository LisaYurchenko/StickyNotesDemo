using StickyNotesDemo.Models;

namespace StickyNotesDemo.Presenters
{
    public class NotesFormPresenter : INotesFormPresenter
    {
        private readonly INoteForm _view;
        private readonly INoteDetailsFormPresenter _noteDetailsFormPresenter;
        private readonly INotesRepository _repository;

        public NotesFormPresenter(INoteForm view,
            INoteDetailsFormPresenter noteDetailsFormPresenter,
            INotesRepository repository)
        {
            _view = view;
            _noteDetailsFormPresenter = noteDetailsFormPresenter;
            _repository = repository;
            _view.SetData(repository.GetAll());
        }

        public Note CreateNote()
        {
            var note = _noteDetailsFormPresenter.CreateNote();
            _repository.Add(note);
            return note;
        }

        public Note UpdateNote(Guid id)
        {
            var note = _repository.GetNoteById(id);
            if (note != null)
            {
                _noteDetailsFormPresenter.SetData(note);
                _noteDetailsFormPresenter.EditNote(ref note);
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
