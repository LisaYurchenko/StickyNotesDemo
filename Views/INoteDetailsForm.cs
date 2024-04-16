using StickyNotesDemo.Presenters;

namespace StickyNotesDemo
{
    public interface INoteDetailsForm
    {
        public string Content
        {
            get; set;
        }
        INoteDetailsFormPresenter NoteDetailsFormPresenter
        {
            get;
        }
        public string Title
        {
            get; set;
        }

        void ShowDialog();
    }
}