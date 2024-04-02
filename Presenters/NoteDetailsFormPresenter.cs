using StickyNotesDemo.Models;

namespace StickyNotesDemo.Presenters
{
    public class NoteDetailsFormPresenter
    {
        private NoteDetailsForm _view;

        public NoteDetailsFormPresenter(NoteDetailsForm view)
        {
            _view = view;
        }

        public Note CreateNote()
        {
            _view.ShowDialog();
            return new Note
            {

                Title = _view.Title,
                Content = _view.Content
            };
        }

        public void EditNote(ref Note note)
        {
            _view.ShowDialog();
            note.Title = _view.Title;
            note.Content = _view.Content;
        }
    }
}
