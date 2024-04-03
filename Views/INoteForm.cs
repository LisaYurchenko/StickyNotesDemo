using StickyNotesDemo.Models;
using StickyNotesDemo.Presenters;

namespace StickyNotesDemo
{
    public interface INoteForm
    {
        INotesFormPresenter NotesFormPresenter
        {
            set;
        }

        void InsertItem(Note note, int id = -1);
        void SetData(IEnumerable<Note> notes);
    }
}