using StickyNotesDemo.Presenters;

namespace StickyNotesDemo
{
    public interface INoteForm
    {
        INotesFormPresenter NotesFormPresenter
        {
            set;
        }

        void InsertItem(string[]? strings, int id = -1);
    }
}