using StickyNotesDemo.Models;

namespace StickyNotesDemo.Presenters
{
    public class NoteDetailsFormPresenter : INoteDetailsFormPresenter
    {
        private INoteDetailsForm _view;

        public NoteDetailsFormPresenter(INoteDetailsForm view)
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

        public void SetData(Note note)
        {
           _view.Title = note.Title;
           _view.Content = note.Content;
        }
    }
}
