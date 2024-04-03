
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace StickyNotesDemo.Models
{
    public class NotesRepository : INotesRepository
    {
        private readonly NotesContext _context;

        public NotesRepository(NotesContext context)
        {
            _context = context;
        }

        public void Add(Note note)
        {

            _context.Notes.Add(note);
            _context.SaveChanges();
        }

        public void Remove(Note note)
        {
            _context.Notes.Remove(note);
            _context.SaveChanges();
        }

        public IEnumerable<Note> GetAll()
        {

            return _context.Notes;
        }

        public Note? GetNoteByTitle(string title)
        {
            return _context.Notes.FirstOrDefault(x => x.Title.Equals(title));
        }

        public void Update(Note newNote)
        {
            var oldNote = _context.Notes.FirstOrDefault(x => x.Id.Equals(newNote.Id));
            if (oldNote != null)
            {
                oldNote.Title = newNote.Title;
                oldNote.Content = newNote.Content;
            }
            _context.SaveChanges();
        }

        public List<Note> GetNotesByTitleContent(string text)
        {
            return _context.Notes.Where(x => x.Title.Contains(text)).ToList();
        }

        public Note GetNoteById(Guid id)
        {
            return _context.Notes.FirstOrDefault(x => x.Id.Equals(id));
        }
    }
}
