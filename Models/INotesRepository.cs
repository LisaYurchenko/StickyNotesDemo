

namespace StickyNotesDemo.Models
{
    public interface INotesRepository
    {
        void Add(Note note);
        IEnumerable<Note> GetAll();
        Note GetNoteById(Guid id);
        Note? GetNoteByTitle(string title);
        List<Note> GetNotesByTitleContent(string title);
        void Remove(Note note);
        void Update(Note newNote);
    }
}