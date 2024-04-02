
namespace StickyNotesDemo.Models
{
    public interface INotesRepository
    {
        void Add(Note note);
        IEnumerable<Note> GetAll();
        Note? GetNoteByTitle(string title);
        List<Note> GetNotesByTitleContent(string text);
        void Remove(Note note);
        void Update(Note newNote);
    }
}