
namespace StickyNotesDemo.Models
{
    public class NotesRepository
    {
        private readonly List<Note> _notes = new();

        public void Add(Note note)
        {

            _notes.Add(note);
        }

        public void Remove(Note note)
        {

            _notes.Remove(note);
        }

        public IEnumerable<Note> GetAll()
        {

            return _notes;
        }

        public Note? GetNoteByTitle(string title)
        {
            return _notes.FirstOrDefault(x => x.Title.Equals(title));
        }

        public void Update(Note newNote)
        {
            var oldNote = _notes.FirstOrDefault(x => x.Id.Equals(newNote.Id));
            if (oldNote != null)
            {
                oldNote.Title = newNote.Title;
                oldNote.Content = newNote.Content;
            }
        }

        internal List<Note> GetNotesByTitleContent(string text)
        {
            return _notes.Where(x => x.Title.Contains(text)).ToList();
        }
    }
}
