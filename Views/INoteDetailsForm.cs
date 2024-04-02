using StickyNotesDemo.Presenters;

namespace StickyNotesDemo
{
    public interface INoteDetailsForm
    {
        string Content
        {
            get;
        }
        INoteDetailsFormPresenter NoteDetailsFormPresenter
        {
            get;
        }
        string Title
        {
            get;
        }

        void ShowDialog();
    }
}