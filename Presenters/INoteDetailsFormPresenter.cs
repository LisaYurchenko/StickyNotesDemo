using StickyNotesDemo.Models;

namespace StickyNotesDemo.Presenters
{
    public interface INoteDetailsFormPresenter
    {
        Note CreateNote();
        void EditNote(ref Note note);
        void SetData(Note note);
    }
}