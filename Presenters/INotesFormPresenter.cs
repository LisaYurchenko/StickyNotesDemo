using StickyNotesDemo.Models;

namespace StickyNotesDemo.Presenters
{
    public interface INotesFormPresenter
    {
        Note CreateNote();
        void DeleteNote(Guid id);
        void FindItems(string text);
        Note UpdateNote(Guid id);
    }
}